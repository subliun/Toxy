using System;
using System.Windows.Forms;
using System.Globalization;

using SharpTox;
using MetroFramework.Forms;
using NAudio.Wave;

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
            txtNospam.Text = tox.GetNospam().ToString();

            toggleTypeDetection.Checked = config["typing_detection"];
            toggleCloseTray.Checked = config["close_to_tray"];

            comboStyle.SelectedIndex = config["form_style"];
            comboColor.SelectedIndex = config["form_color"];

            int devices = WaveIn.DeviceCount;
            for (int i = 0; i < devices; i++)
                comboInput.Items.Add(WaveIn.GetCapabilities(i).ProductName);

            devices = WaveOut.DeviceCount;
            for (int i = 0; i < devices; i++)
                comboOutput.Items.Add(WaveOut.GetCapabilities(i).ProductName);

            if (comboInput.Items.Count != 0)
            {
                if (comboInput.Items.Count > (int)config["device_input"])
                    comboInput.SelectedIndex = config["device_input"];
            }

            if (comboOutput.Items.Count != 0)
            {
                if (comboOutput.Items.Count > (int)config["device_output"])
                    comboOutput.SelectedIndex = config["device_output"];
            }
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

            uint nospam;
            if (!uint.TryParse(txtNospam.Text, out nospam))
            {
                MessageBox.Show("The nospam value you've entered doesn't seem valid!", "Invalid nospam value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else { tox.SetNospam(nospam); }

            config["typing_detection"] = toggleTypeDetection.Checked;

            config["form_style"] = comboStyle.SelectedIndex;
            config["form_color"] = comboColor.SelectedIndex;
            config["close_to_tray"] = toggleCloseTray.Checked;

            config["device_input"] = comboInput.SelectedIndex;
            config["device_output"] = comboOutput.SelectedIndex;

            config.Save("toxy.cfg");

            Close();
        }
    }
}
