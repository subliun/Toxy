using System;
using System.Runtime.InteropServices;

namespace Toxy
{
    class OpenAL
    {
        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr alcGetString([In] IntPtr device, int name);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void alcCaptureStart(IntPtr device);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void alcCaptureSamples(IntPtr device, IntPtr buffer, int sample_count);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr alcCaptureOpenDevice(string deviceName, uint frequency, int format, int buffer_size);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void alcGetIntegerv(IntPtr device, int param, int size, ref int data);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr alcOpenDevice(string deviceName);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe extern static IntPtr alcCreateContext(IntPtr device, [In] int* attr_list);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void alcMakeContextCurrent(IntPtr context);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void alGetSourcei(uint source_id, int prop, out int value);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void alSourcePlay(uint source_id);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void alSourceQueueBuffers(uint source_id, int number, uint[] buffer_id);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void alSourceUnqueueBuffers(uint source_id, int buffer_count, uint[] buffers);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void alGenSources(int count, [Out] uint* sources);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void alDeleteSources(int count, uint[] sources);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int alGetError();

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int alcGetError(IntPtr device);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void alSourcei(uint source_id, int prop, int value);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void alGenBuffers(int count, out uint buffers);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void alBufferData(uint buffer_id, int format, ushort[] data, int byte_size, uint freq);

        [DllImport("OpenAL32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void alDeleteBuffers(int buffer_count, uint[] buffer_ids);
    }
}
