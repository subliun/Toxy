using System;
using System.Windows.Forms;

using SharpTox;

using MetroFramework.Forms;

namespace Toxy
{
    public partial class frmOptions : MetroForm
    {
        private Tox tox;
        public frmOptions(Tox tox)
        {
            this.tox = tox;

            InitializeComponent();
        }

        private void btnCopyID_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tox.GetAddress());
        }
    }
}
