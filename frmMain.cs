using System;   
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
using System.Configuration;
using AvencaLib;

namespace FidelidadeCPF
{
    public partial class frmMain : Form
    {
        public static string strVersion = "2.0";

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string sClass, string sWindow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public static IntPtr hwndLastApp;
        public static IntPtr hwndFrmFidelidade;
        public static IntPtr hwndMessage;
        
        public static int idFuncionario;

        bool isShutdown = false;
        frmFidelidade frmFidelidade1;
        public frmMessageBox msgForm;
        public bool isConfirmation = false;
        private bool isMyKeySent = false;
        SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
        AvencaDataSetTableAdapters.FidelidadeTableAdapter fidelidadeTableAdapter = new AvencaDataSetTableAdapters.FidelidadeTableAdapter();
        AvencaDataSetTableAdapters.QueriesTableAdapter queriesTableAdapter = new AvencaDataSetTableAdapters.QueriesTableAdapter();

        private const int WM_ACTIVATEAPP = 0x001C;
        private const int WM_NCLBUTTONDBLCLK = 0x00A3;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int WM_QUERYENDSESSION = 0x11;

        private System.IO.FileSystemWatcher fw;
        private static string lastCreatedFileName;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_QUERYENDSESSION:
                    isShutdown = true;
                    break;
            }
            base.WndProc(ref m);
        }

        public frmMain()
        {
            
            //fidelidadeTableAdapter.Connection.ConnectionString = AvencaDB.ConnectionString;
            //FidelidadeCPF.Properties.Settings.Default.AvencaConnectionStringDebug = AvencaDB.ConnectionString;
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "Avenca Fidelidade - v" + strVersion;
            Logon();

            //fw = new System.IO.FileSystemWatcher();
            //fw.Path = @"C:\Colibri 8\temp";
            //fw.Filter = "*.WXT";
            //fw.IncludeSubdirectories = false;
            //fw.EnableRaisingEvents = true;
            //fw.Created += new FileSystemEventHandler(OnCreated);
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            File.Move(e.FullPath, e.FullPath + ".BAK");
            lastCreatedFileName = e.FullPath + ".BAK";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            if((!isShutdown) && (AvencaPermission.Usuario.IdPermissionGroup > 0))
                if (frmMessageBox.ShowDialog(this, "Deseja mesmo fechar o aplicativo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, ref this.msgForm) == DialogResult.No)
                    e.Cancel = true;
        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            long result;

            if (txtCPF.Text.Length > 0)
            {
                if (Int64.TryParse(txtCPF.Text, out result))
                {
                    clienteBindingSource.Filter = string.Format("CPF LIKE '{0}%'", txtCPF.Text);
                }
                else
                {
                    clienteBindingSource.Filter = string.Format("Nome LIKE '%{0}%'", txtCPF.Text);
                }
            }
            else
            {
                clienteBindingSource.Filter = "CPF = '-'";
            }
        }

        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                showFidelidade();
                e.Handled = true;
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showFidelidade();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            showFidelidade();
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Enabled)
            {
                switch (e.KeyChar)
                {
                    case '*':
                        if (this.WindowState != FormWindowState.Minimized)
                        {
                            this.WindowState = FormWindowState.Minimized;
                            e.Handled = true;
                        }
                        break;
                    case '/':
                        clienteBindingSource.Filter = "CPF = '-'";
                        txtCPF.Text = "";
                        txtCPF.Focus();
                        e.Handled = true;
                        break;
                    default:
                        if (!txtCPF.Focused)
                        {
                            txtCPF.Text += e.KeyChar;
                            txtCPF.Focus();
                        }
                        e.Handled = false;
                        break;
                }
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            this.clienteTableAdapter.Fill(this.avencaDataSet.Cliente);
            clienteBindingSource.Filter = "CPF = '-'";
            txtCPF.Text = "";
            txtCPF.Focus();
            if (this.WindowState == FormWindowState.Minimized)
                timer1.Enabled = true;
        }

        private void Logon(bool isLogoff = false)
        {
            this.Enabled = false;
            if (AvencaPermission.RequestLogin(this, isLogoff) == 0)
            {
                isShutdown = true;
                this.Close();
            }
            else
            {
                this.Enabled = true;
                if (!isLogoff)
                {
                    frmFlashScreen fs = new frmFlashScreen();
                    fs.ShowDialog(this);
                }
                this.clienteTableAdapter.Fill(this.avencaDataSet.Cliente);
                dgvClientes.Columns["Nome"].Visible = AvencaPermission.HasPermission(dgvClientes);
                usernameToolStripMenuItem.Text = AvencaPermission.Usuario.Username.ToUpper();
                this.WindowState = FormWindowState.Minimized;
                this.Show();
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void Logoff()
        {
            AvencaPermission.Logoff();
        }

        private void showFidelidade()
        {
            bool hasPermission = AvencaPermission.HasPermission(dgvClientes);

            if (hasPermission || (dgvClientes.RowCount <= 1))
            {
                if (dgvClientes.SelectedRows.Count > 0)
                {
                    try
                    {
                        int id = (int)dgvClientes.SelectedRows[0].Cells[0].Value;
                        string nome = dgvClientes.SelectedRows[0].Cells[1].Value.ToString();
                        string cpf = dgvClientes.SelectedRows[0].Cells[2].Value.ToString();
                        string empresa = dgvClientes.SelectedRows[0].Cells[3].Value.ToString();

                        frmFidelidade1 = new frmFidelidade(this, id, nome, cpf, empresa);
                        frmFidelidade1.ShowDialog(this);
                    }
                    finally
                    {
                        frmFidelidade1.Dispose();
                        frmFidelidade1 = null;
                    }
                }
                else this.WindowState = FormWindowState.Minimized;
            }
        }

        public void insertFidelidade(int idCliente)
        {
            fidelidadeTableAdapter.Insert(DateTime.Now, idCliente, AvencaPermission.Usuario.Id);
        }

        public void deleteFidelidade(int idCliente)
        {
            fidelidadeTableAdapter.Delete(idCliente);
        }

        public void useFidelidade(int idCliente)
        {
            queriesTableAdapter.USE_FIDELIDADE(idCliente, AvencaPermission.Usuario.Id);
        }

        public void revertFidelidade(int idCliente)
        {
            queriesTableAdapter.REVERT_FIDELIDADE(idCliente);
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                dgvClientes.Columns["Nome"].Visible = AvencaPermission.HasPermission(dgvClientes);
                if (txtCPF.Mask == "??????????????????????????????")
                    txtCPF.Mask = @"999\.999\.999\-99";
            }
            else
            {
                dgvClientes.Columns["Nome"].Visible = true;
                txtCPF.Mask = "??????????????????????????????";
            }
        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 2)
                e.Value = string.Format(@"{0:000\.000\.000\-00}", Int64.Parse((e.Value.ToString())));
        }

        private void globalEventProvider1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(this.Enabled)
                handleKeys(e);
            //PrintScreen();
        }

//        public void handleKeys(KeyPressEventArgs e)
//        {
//#if !TEST
//            string[] descontosCommands;

//            switch (e.KeyChar)
//            {
//                case '*':
//                    if (this.WindowState == FormWindowState.Minimized)
//                    {
//                        IntPtr p = GetForegroundWindow();
//                        if (p != this.Handle && hwndFrmFidelidade == (IntPtr)0 && hwndMessage == (IntPtr)0)
//                            hwndLastApp = p;

//                        this.WindowState = FormWindowState.Normal;
//                        e.Handled = true;
//                    }
//                    if (!this.ContainsFocus && (frmFidelidade1 == null ? true : !frmFidelidade1.ContainsFocus))
//                    {
//                        if (frmFidelidade1 == null)
//                        {
//                            this.WindowState = FormWindowState.Minimized;
//                            this.Show();
//                            this.WindowState = FormWindowState.Normal;
//                            this.Activate();
//                        }
//                        else
//                        {
//                            this.WindowState = FormWindowState.Minimized;
//                            this.Show();
//                            this.WindowState = FormWindowState.Normal;
//                            frmFidelidade1.Activate();
//                        }

//                        e.Handled = true;
//                    }
//                    if (msgForm != null)
//                    {
//                        this.WindowState = FormWindowState.Minimized;
//                        this.Show();
//                        this.WindowState = FormWindowState.Normal;
//                        msgForm.Activate();

//                        e.Handled = true;
//                    }
//                    break;
//                //case '.':
//                //    Application.Exit();
//                //    e.Handled = true;
//                //    break;
//                case '+':
//                    if (msgForm != null)
//                    {
//                        if (msgForm.mbButtons == MessageBoxButtons.OK)
//                            SendKeys.Send("{ENTER}");
//                        else
//                            SendKeys.Send("s");
//                        e.Handled = true;
//                    }
//                    break;
//                case '-':
//                    if (msgForm != null)
//                    {
//                        if (msgForm.mbButtons == MessageBoxButtons.OK)
//                            SendKeys.Send("{ENTER}");
//                        else
//                            SendKeys.Send("n");
//                        e.Handled = true;
//                    }
//                    break;
//                case ' ': // NENHUM DESCONTO
//                    if (isColibriActive())
//                    {
//                        SendKeys.SendWait("{F9}");
//                        System.Threading.Thread.Sleep(50);
//                        SendKeys.SendWait("{DIVIDE}");
//                        System.Threading.Thread.Sleep(50);
//                        SendKeys.SendWait("{ENTER}");
//                        System.Threading.Thread.Sleep(50);
//                        SendKeys.SendWait("{ADD}");
//                        e.Handled = true;
//                    }
//                    break;
//                case 'g': // GLOBO
//                    if (isColibriActive())
//                    {
//                        SendKeys.SendWait("{F9}");
//                        System.Threading.Thread.Sleep(50);
//                        SendKeys.SendWait("{DIVIDE}");
//                        System.Threading.Thread.Sleep(50);
//                        SendKeys.SendWait("{DOWN}");
//                        System.Threading.Thread.Sleep(50);
//                        SendKeys.SendWait("{ENTER}");
//                        System.Threading.Thread.Sleep(50);
//                        SendKeys.SendWait("{ADD}");
//                        e.Handled = true;
//                    }
//                    break;
//                case 'd': // GLOBO FIDELIDADE
//                    if (!isColibriActive())
//                    {
//                        descontosCommands = Properties.Settings.Default.d.Split(';');
//                        for (int i = 0; i < descontosCommands.Length; i++)
//                        {
//                            SendKeys.SendWait(descontosCommands[i]);
//                            System.Threading.Thread.Sleep(50);
//                        }
//                        e.Handled = true;
//                    }
//                    break;
//                case 'f': // FIDELIDADE
//                    if (isColibriActive())
//                    {
//                        SendKeys.SendWait("{F9}");
//                        System.Threading.Thread.Sleep(50);
//                        SendKeys.SendWait("{DIVIDE}");
//                        System.Threading.Thread.Sleep(50);
//                        SendKeys.SendWait("{DOWN}");
//                        System.Threading.Thread.Sleep(50);
//                        SendKeys.SendWait("{DOWN}");
//                        System.Threading.Thread.Sleep(50);
//                        SendKeys.SendWait("{ENTER}");
//                        System.Threading.Thread.Sleep(50);
//                        SendKeys.SendWait("{ADD}");
//                        e.Handled = true;
//                    }
//                    break;
//                case 'i': // CONSUMO INTERNO
//                    if (isColibriActive())
//                    {
//                        SendKeys.SendWait("{F9}");
//                        SendKeys.SendWait("{DIVIDE}");
//                        SendKeys.SendWait("{DOWN}");
//                        SendKeys.SendWait("{DOWN}");
//                        SendKeys.SendWait("{DOWN}");
//                        SendKeys.SendWait("{DOWN}");
//                        SendKeys.SendWait("{DOWN}");
//                        SendKeys.SendWait("{DOWN}");
//                        SendKeys.SendWait("{ENTER}");
//                        SendKeys.SendWait("{ENTER}");
//                        SendKeys.SendWait("{ADD}");
//                        e.Handled = true;
//                    }
//                    break;
//                case 't': // LANÇA TRIDENT
//                    if (isColibriActive())
//                    {
//                        SendKeys.SendWait("{F6}");
//                        System.Threading.Thread.Sleep(800);
//                        SendKeys.SendWait("T");
//                        System.Threading.Thread.Sleep(300);
//                        SendKeys.SendWait("{ENTER}");
//                        e.Handled = true;
//                    }
//                    break;
//                case 'h': // LANÇA HALLS
//                    if (isColibriActive())
//                    {
//                        SendKeys.SendWait("{F6}");
//                        System.Threading.Thread.Sleep(800);
//                        SendKeys.SendWait("H");
//                        System.Threading.Thread.Sleep(300);
//                        SendKeys.SendWait("{ENTER}");
//                        e.Handled = true;
//                    }
//                    break;
//                case 'b': // LANÇA BRIGADEIRO
//                    if (isColibriActive())
//                    {
//                        SendKeys.SendWait("{F6}");
//                        System.Threading.Thread.Sleep(800);
//                        SendKeys.SendWait("B");
//                        System.Threading.Thread.Sleep(300);
//                        SendKeys.SendWait("{ENTER}");
//                        e.Handled = true;
//                    }
//                    break;
//                case 'm': // LANÇA MENTOS
//                    if (isColibriActive())
//                    {
//                        SendKeys.SendWait("{F6}");
//                        System.Threading.Thread.Sleep(800);
//                        SendKeys.SendWait("M");
//                        System.Threading.Thread.Sleep(300);
//                        SendKeys.SendWait("{ENTER}");
//                        e.Handled = true;
//                    }
//                    break;
//                case 'n': // LANÇA MENTOS MINI
//                    if (isColibriActive())
//                    {
//                        SendKeys.SendWait("{F6}");
//                        System.Threading.Thread.Sleep(800);
//                        SendKeys.SendWait("N");
//                        System.Threading.Thread.Sleep(300);
//                        SendKeys.SendWait("{ENTER}");
//                        e.Handled = true;
//                    }
//                    break;
//                case 'c': // LANÇA TIC TAC
//                    if (isColibriActive())
//                    {
//                        SendKeys.SendWait("{F6}");
//                        System.Threading.Thread.Sleep(800);
//                        SendKeys.SendWait("C");
//                        System.Threading.Thread.Sleep(300);
//                        SendKeys.SendWait("{ENTER}");
//                        e.Handled = true;
//                    }
//                    break;
//                default:
//                    e.Handled = false;
//                    break;
//            }
//#endif
//        }

        public void handleKeys(KeyPressEventArgs e)
        {
#if !TEST
            string[] descontosCommands;

            if (!isMyKeySent)
            {
                switch (e.KeyChar)
                {
                    case '*':
                        if (this.WindowState == FormWindowState.Minimized)
                        {
                            IntPtr p = GetForegroundWindow();
                            if (p != this.Handle && hwndFrmFidelidade == (IntPtr)0 && hwndMessage == (IntPtr)0)
                                hwndLastApp = p;

                            this.WindowState = FormWindowState.Normal;
                            e.Handled = true;
                        }
                        if (!this.ContainsFocus && (frmFidelidade1 == null ? true : !frmFidelidade1.ContainsFocus))
                        {
                            if (frmFidelidade1 == null)
                            {
                                this.WindowState = FormWindowState.Minimized;
                                this.Show();
                                this.WindowState = FormWindowState.Normal;
                                this.Activate();
                            }
                            else
                            {
                                this.WindowState = FormWindowState.Minimized;
                                this.Show();
                                this.WindowState = FormWindowState.Normal;
                                frmFidelidade1.Activate();
                            }

                            e.Handled = true;
                        }
                        if (msgForm != null)
                        {
                            this.WindowState = FormWindowState.Minimized;
                            this.Show();
                            this.WindowState = FormWindowState.Normal;
                            msgForm.Activate();

                            e.Handled = true;
                        }
                        break;
                    case '+':
                        if (msgForm != null)
                        {
                            if (msgForm.mbButtons == MessageBoxButtons.OK)
                                SendKeys.Send("{ENTER}");
                            else
                                SendKeys.Send("s");
                            e.Handled = true;
                        }
                        break;
                    case '-':
                        if (msgForm != null)
                        {
                            if (msgForm.mbButtons == MessageBoxButtons.OK)
                                SendKeys.Send("{ENTER}");
                            else
                                SendKeys.Send("n");
                            e.Handled = true;
                        }
                        break;
                    default:
                        if (isColibriActive())
                        {
                            string key = e.KeyChar.ToString();

                            if (key == " ")
                                key = "SPACE";
                            
                            if (DoesSettingExist(key))
                            {
                                isMyKeySent = true;
                                descontosCommands = Properties.Settings.Default[key.ToString()].ToString().Split(';');
                                int delay = int.Parse(descontosCommands[0]);
                                for (int i = 1; i < descontosCommands.Length; i++)
                                {
                                    SendKeys.SendWait(descontosCommands[i]);
                                    System.Threading.Thread.Sleep(delay);
                                }
                                isMyKeySent = false;
                                e.Handled = true;
                            }
                            else
                                e.Handled = false;
                        }
                        else
                            e.Handled = false;
                        break;
                }
            }
#endif
        }

        private bool DoesSettingExist(string settingName)
        {
            return Properties.Settings.Default.Properties.Cast<SettingsProperty>().Any(prop => prop.Name == settingName);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (this.WindowState == FormWindowState.Minimized)
                SetForegroundWindow(hwndLastApp);
        }

        private bool isColibriActive()
        {
            IntPtr h;
            if ((h = GetForegroundWindow()) != IntPtr.Zero)
            {
                uint procId = 0;
                GetWindowThreadProcessId((IntPtr)h, out procId);
                if (Process.GetProcessById((int)procId).ProcessName.Contains("colibri"))
                {
                    return true;
                }
            }
            return false;
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(frmHelp fHelp = new frmHelp())
            {
                fHelp.ShowDialog();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            int currentRow;
            switch (e.KeyCode)
            {
                case Keys.Down:
                    currentRow = dgvClientes.SelectedRows[0].Index;
                    if (currentRow < dgvClientes.RowCount - 1)
                    {
                        dgvClientes.Rows[++currentRow].Selected = true;
                        dgvClientes.FirstDisplayedScrollingRowIndex = dgvClientes.SelectedRows[0].Index > 5 ? dgvClientes.SelectedRows[0].Index - 5 : 0;
                    }
                    e.Handled = true;
                    break;
                case Keys.Up:
                    currentRow = dgvClientes.SelectedRows[0].Index;
                    if (currentRow > 0)
                    {
                        dgvClientes.Rows[--currentRow].Selected = true;
                        dgvClientes.FirstDisplayedScrollingRowIndex = dgvClientes.SelectedRows[0].Index > 5 ? dgvClientes.SelectedRows[0].Index - 5 : 0;
                    }
                    e.Handled = true;
                    break;
                default:
                    break;
            }
        }

        private void tmrLogoff_Tick(object sender, EventArgs e)
        {
            TimeSpan t = DateTime.Now.Subtract(DateTime.Parse("11:00"));
            if (t.TotalMinutes > 0)
                Logoff();
        }

        private void usernameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Select();
            Logoff();
            Logon(true);
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            txtCPF.Text = "";
            txtCPF.Focus();
        }

        private void PrintScreen(int x = -1, int y = -1)
        {
            Pen p = new Pen(Color.Red, 5);
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics;
            string prtScrPath;

            graphics = Graphics.FromImage(bitmap as Image);
            prtScrPath = Properties.Settings.Default.PRTSCRPATH;

            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            if (x >= 0 && y >= 0)
            {
                graphics.DrawEllipse(p, x-5, y-5, 10, 10);
            }
            var date = DateTime.Now.ToString("MMddyyHmmssfff");
            bitmap.Save(@prtScrPath + @"\printscreen" + date + ".jpg", ImageFormat.Jpeg);

            p.Dispose();
            bitmap.Dispose();
            graphics.Dispose();
        }

        private void prtscrThreadMethod()
        {
            PrintScreen();
        }

        private void novoFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvencaFuncionario.NovoFuncionario();
        }
    }
}
