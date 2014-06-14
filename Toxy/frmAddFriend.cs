using System;
using System.Windows.Forms;

using SharpTox;
using MetroFramework.Forms;

namespace Toxy
{
    public partial class frmAddFriend : MetroForm
    {
        public string ID;
        public string Message;
        public frmAddFriend()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!(!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtMessage.Text)))
                return;

            if (txtID.Text.Contains("@"))
            {
                try
                {
                    string id = DnsTools.DiscoverToxID(txtID.Text);
                    txtID.Text = id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not find a tox id:\n" + ex.ToString());
                }

                return;
            }

            ID = txtID.Text;
            Message = txtMessage.Text;

            DialogResult = DialogResult.OK;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
