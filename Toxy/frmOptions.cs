using System;
using System.Windows.Forms;

using SharpTox;

using MetroFramework.Forms;

namespace Toxy
{
    public partial class frmOptions : MetroForm
    {
        private Tox tox;
        private Config config;
        public frmOptions(Tox tox)
        {
            this.tox = tox;
            config = Config.Instance;

            InitializeComponent();

            txtUsername.Text = tox.GetSelfName();
            txtStatusMessage.Text = tox.GetSelfStatusMessage();

            toggleTypeDetection.Checked = config["typing_detection"];
            toggleEncryption.Checked = config["enable_encryption"];

            comboStyle.SelectedIndex = config["form_style"];
            comboColor.SelectedIndex = config["form_color"];

        }

        private void btnCopyID_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tox.GetAddress());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tox.SetName(txtUsername.Text);
            tox.SetStatusMessage(txtStatusMessage.Text);

            config["typing_detection"] = toggleTypeDetection.Checked;
            config["enable_encryption"] = toggleEncryption.Checked;

            config["form_style"] = comboStyle.SelectedIndex;
            config["form_color"] = comboColor.SelectedIndex;

            config.Save("toxy.cfg");

            Close();
        }
    }
}
