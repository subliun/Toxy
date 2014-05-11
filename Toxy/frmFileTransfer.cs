using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;

using SharpTox;

using MetroFramework.Forms;
using System.Text;

namespace Toxy
{
    public partial class frmFileTransfer : MetroForm
    {
        public event EventHandler OnTransferComplete;

        private Tox tox;

        public int FriendNumber;
        public int FileNumber;

        private ulong filesize;
        private string filename;

        private int send_receive;
        private bool finished = false;

        private FileStream stream;

        public frmFileTransfer(Tox tox, int friendnumber, int filenumber, ulong filesize, string filename, int send_receive)
        {
            this.tox = tox;
            this.FriendNumber = friendnumber;
            FileNumber = filenumber;
            this.filesize = filesize;
            this.filename = filename;
            this.send_receive = send_receive;

            InitializeComponent();

            if (send_receive == 1)
                lblMessage.Text = string.Format("{0} would like to share {1} ({2} bytes) with you, do you want to accept this file transfer?", tox.GetName(friendnumber), filename, filesize.ToString());
            else
                lblMessage.Text = string.Format("You're about to send {0} to {1}", filename.Split('\\')[filename.Split('\\').Length - 1], tox.GetName(friendnumber));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!finished)
                tox.FileSendControl(FriendNumber, send_receive, FileNumber, ToxFileControl.KILL, new byte[0]);

            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (send_receive == 1)
            {
                tox.FileSendControl(FriendNumber, 1, FileNumber, (int)ToxFileControl.ACCEPT, new byte[0]);
                stream = new FileStream(filename, FileMode.Create);

                btnAccept.Enabled = false;
                lblStatus.Text = "Transferring...";
            }
            else
            {
                FileNumber = tox.NewFileSender(FriendNumber, filesize, filename);

                btnAccept.Enabled = false;
                lblStatus.Text = "Waiting for response...";
            }
        }

        public void ProcessFileControl(ToxFileControl control)
        {
            switch (control)
            {
                case ToxFileControl.FINISHED:
                    {
                        if (stream != null)
                            stream.Close();

                        OnTransferComplete(this, new EventArgs());

                        finished = true;
                        lblStatus.Text = "Finished.";
                        btnCancel.Text = "Close";
                        break;
                    }
                case ToxFileControl.KILL:
                    {
                        if (stream != null)
                            stream.Close();

                        finished = true;
                        lblStatus.Text = "Cancelled.";
                        btnCancel.Text = "Close";
                        break;
                    }
                case ToxFileControl.ACCEPT:
                    {
                        lblStatus.Text = "Transferring...";

                        new Thread(delegate()
                        {
                            int chunk_size = tox.FileDataSize(FriendNumber);

                            using (var file = File.OpenRead(filename))
                            {
                                int bytes_read;
                                var bytes = new byte[chunk_size];
                                while ((bytes_read = file.Read(bytes, 0, bytes.Length)) > 0)
                                {
                                    tox.FileSendData(FriendNumber, FileNumber, bytes);
                                    Thread.Sleep(10);
                                }
                            }

                            tox.FileSendControl(FriendNumber, 0, FileNumber, ToxFileControl.FINISHED, new byte[0]);

                            Invoke(((Action)(() => lblStatus.Text = "Finished.")));

                        }).Start();

                        break;
                    }
            }
        }

        public void AddData(byte[] data)
        {
            if (stream == null)
                throw new Exception("Unexpectedly received data");

            ulong remaining = tox.FileDataRemaining(FriendNumber, FileNumber, 1);
            double value = (double)tox.FileDataRemaining(FriendNumber, FileNumber, 1) / (double)filesize;

            metroProgressBar1.Value = 100 - (int)(value * 100);
            lblStatus.Text = string.Format("Transferring...   {0}/{1}", filesize - remaining, filesize);

            stream.Write(data, 0, data.Length);
        }
    }
}
