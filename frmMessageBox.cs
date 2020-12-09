using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FidelidadeCPF
{
    public partial class frmMessageBox : Form
    {
        public MessageBoxButtons mbButtons;

        public frmMessageBox()
        {
            InitializeComponent();
        }

        public static DialogResult ShowDialog(IWin32Window owner, string caption, string text, MessageBoxButtons buttons, MessageBoxIcon icon, ref frmMessageBox messageForm)
        {
            using (frmMessageBox message = new frmMessageBox())
            {
                messageForm = message;

                frmMain.hwndMessage = message.Handle;

                message.mbButtons = buttons;

                message.Text = caption;

                if (buttons == MessageBoxButtons.YesNo)
                {
                    message.btnNo.Enabled = message.btnNo.Visible = true;
                    message.btnYes.Enabled = message.btnYes.Visible = true;
                }
                else
                {
                    message.btnOK.Enabled = message.btnOK.Visible = true;
                }

                message.lblMessage.Text = text;

                if (icon == MessageBoxIcon.Warning)
                    message.pbIcon.Image = FidelidadeCPF.Properties.Resources.warning;
                else message.pbIcon.Image = FidelidadeCPF.Properties.Resources.question;

                DialogResult ret;
                    
                ret = message.ShowDialog(owner);

                //ret = ret == DialogResult.Cancel ? DialogResult.No : ret;

                frmMain.hwndMessage = (IntPtr)0;
                messageForm = null;

                return ret;
            }
        }

        private void frmMessageBox_Shown(object sender, EventArgs e)
        {
            this.Width = this.lblMessage.Left + this.lblMessage.Width + 30;
        }

        private void frmMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
