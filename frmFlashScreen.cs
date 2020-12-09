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
    public partial class frmFlashScreen : Form
    {
        public frmFlashScreen()
        {
            InitializeComponent();
        }

        private void frmFlashScreen_Shown(object sender, EventArgs e)
        {
            lblNameVersion.Text = frmMain.strVersion;
            Application.DoEvents();
            System.Threading.Thread.Sleep(1000);
            this.WindowState = FormWindowState.Minimized;
            Application.DoEvents();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
