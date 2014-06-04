﻿using System;
using System.Threading;
using System.Windows.Forms;

using SharpTox;
using MetroFramework.Forms;
using NAudio.Wave;

namespace Toxy
{
    public partial class frmCall : MetroForm
    {
        private Tox tox;
        private ToxAv toxav;

        private Config config;

        private WaveIn wave_source;
        private WaveOut wave_out;
        private BufferedWaveProvider wave_provider;

        private Thread thread;

        private uint frame_size;

        public int CallIndex;

        public frmCall(Tox tox, ToxAv toxav)
        {
            InitializeComponent();

            this.tox = tox;
            this.toxav = toxav;

            config = Config.Instance;
        }

        public void Start()
        {
            if (WaveIn.DeviceCount < 1)
                throw new Exception("Insufficient input device(s)!");

            if (WaveOut.DeviceCount < 1)
                throw new Exception("Insufficient output device(s)!");

            frame_size = toxav.CodecSettings.audio_sample_rate * toxav.CodecSettings.audio_frame_duration / 1000;

            toxav.PrepareTransmission(CallIndex, false);

            WaveFormat format = new WaveFormat((int)toxav.CodecSettings.audio_sample_rate, (int)toxav.CodecSettings.audio_channels);
            wave_provider = new BufferedWaveProvider(format);
            wave_provider.DiscardOnBufferOverflow = true;

            wave_out = new WaveOut();
            wave_out.DeviceNumber = config["device_out"];
            wave_out.Init(wave_provider);

            wave_source = new WaveIn(this.Handle);
            wave_source.DeviceNumber = config["device_in"];
            wave_source.WaveFormat = format;
            wave_source.DataAvailable += wave_source_DataAvailable;
            wave_source.RecordingStopped += wave_source_RecordingStopped;
            wave_source.BufferMilliseconds = (int)toxav.CodecSettings.audio_frame_duration;
            wave_source.StartRecording();

            thread = new Thread(receive);
            thread.Start();

            Text = "Calling " + tox.GetName(toxav.GetPeerID(CallIndex, 0));
        }

        private void wave_source_RecordingStopped(object sender, StoppedEventArgs e)
        {
            Console.WriteLine("Recording stopped");
        }

        private void receive()
        {
            wave_out.Play();

            while (true)
            {
                short[] pcm = new short[frame_size];

                int received = toxav.ReceiveAudio(CallIndex, (int)frame_size, pcm);
                if (received > 0)
                {
                    byte[] bytes = ShortArrayToByteArray(pcm);
                    wave_provider.AddSamples(bytes, 0, bytes.Length);
                }
                else if (received != (int)ToxAvError.None)
                {
                    Console.WriteLine("Could not receive data: {0}", (ToxAvError)received);
                }
            }
        }

        private byte[] ShortArrayToByteArray(short[] shorts)
        {
            byte[] bytes = new byte[shorts.Length * 2];

            for (int i = 0; i < shorts.Length; ++i)
            {
                bytes[2 * i] = (byte)shorts[i];
                bytes[2 * i + 1] = (byte)(shorts[i] >> 8);
            }

            return bytes;
        }

        private void wave_source_DataAvailable(object sender, WaveInEventArgs e)
        {
            ushort[] ushorts = new ushort[e.Buffer.Length / 2];
            Buffer.BlockCopy(e.Buffer, 0, ushorts, 0, e.Buffer.Length);

            byte[] dest = new byte[65535];
            int size = toxav.PrepareAudioFrame(CallIndex, dest, 65535, ushorts, ushorts.Length);

            if (toxav.SendAudio(CallIndex, ref dest, size) != ToxAvError.None)
                Console.WriteLine("Could not send audio");
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            Stop();
        }

        public void EndCall()
        {
            Stop();
        }

        private void Stop()
        {
            if (thread != null)
            {
                thread.Abort();
                thread.Join();

                toxav.KillTransmission(CallIndex);
            }

            toxav.Hangup(CallIndex);

            Close();
        }

        public void Answer()
        {
            ToxAvError error = toxav.Answer(CallIndex, ToxAvCallType.Audio);
            if (error != ToxAvError.None)
            {
                string err = error.ToString();
                MessageBox.Show("Could not answer call! " + err);
                Close();
            }
            else
            {
                Start();
            }
        }

        public void Call(int current_number, ToxAvCallType call_type, int ringing_seconds)
        {
            toxav.Call(ref CallIndex, current_number, call_type, ringing_seconds);
        }
    }
}
