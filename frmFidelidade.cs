using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using AvencaLib;

namespace FidelidadeCPF
{
    public partial class frmFidelidade : Form
    {
        public const int ADD_FIDELIDADE = 0;
        public const int USE_FIDELIDADE = 1;
        public const int DELETE_FIDELIDADE = 2;
        public const int REVERT_FIDELIDADE = 3;
        public const int PRINT_HISTORY = 4;

        frmMain mainForm;
        int clientId;
        StringBuilder output = new StringBuilder();
        bool added;
        bool used;

        public frmFidelidade()
        {
            InitializeComponent();
        }

        public frmFidelidade(frmMain form, int id, string nome, string cpf, string empresa)
        {
            mainForm = form;
            clientId = id;
            added = false;
            used = false;

            InitializeComponent();

            lblNome.Text = nome.ToUpperInvariant();
            string formattedCPF = cpf.Substring(0, 3) + "." + cpf.Substring(3, 3) + "." + cpf.Substring(6, 3) + "-" + cpf.Substring(9, 2);
            lblCPF.Text = formattedCPF;
            lblEmpresa.Text = empresa;
        }

        private void frmFidelidade_Load(object sender, EventArgs e)
        {
            frmMain.hwndFrmFidelidade = this.Handle;

            bool hasPermission = AvencaPermission.HasPermission(dgvFidelidade);
            dgvFidelidade.Columns["IdFuncionarioCarimbo"].Visible = hasPermission;
            dgvFidelidade.Columns["IdFuncionarioUso"].Visible = hasPermission;

            refreshGridView();
        }

        private void refreshGridView()
        {
            if(frmMain.idFuncionario == 3)
                dgvFidelidade.Columns["IdFuncionario"].Visible = false;
            this.fidelidadeTableAdapter.FillById(this.avencaDataSet.Fidelidade, clientId);

            dgvFidelidade.Columns["Weekday"].DataPropertyName = "Weekday";
            foreach (DataGridViewRow row in dgvFidelidade.Rows)
            {
                row.Cells[0].Value = (row.Index + 1).ToString();
            }
            dgvFidelidade.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            if (dgvFidelidade.Rows.Count > 0)
                dgvFidelidade.Rows[dgvFidelidade.Rows.Count - 1].Selected = true;

            lblLastUse.Text = this.fidelidadeTableAdapter.GetLastUsoById(clientId).ToString();
            lblFidelidades.Text = this.fidelidadeTableAdapter.GetFidelidadeAcumulado(clientId).ToString();
            if ((int)this.fidelidadeTableAdapter.GetFidelidadeAcumulado(clientId) > 0)
            {
                btnUseFidelidade.BackColor = Color.Red;
                btnUseFidelidade.ForeColor = Color.Yellow;
            }
            else
            {
                btnUseFidelidade.BackColor = Color.FromName("Control");
                btnUseFidelidade.ForeColor = Color.Silver;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Return)
            {
                this.Close();
                mainForm.WindowState = FormWindowState.Minimized;
                //if (used)
                //{
                //    System.Threading.Thread.Sleep(100);
                //    KeyPressEventArgs e = new KeyPressEventArgs('f');
                //    mainForm.handleKeys(e);
                //}
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmFidelidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '*':
                    btnUseFidelidade_Click(sender, e);
                    break;
                case '-':
                    btnMinus_Click(sender, e);
                    break;
                case '+':
                    btnPlus_Click(sender, e);
                    break;
                case '/':
                    btnPrint_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void printHistory()
        {
            AvencaDataSetTableAdapters.GET_HISTORYTableAdapter taHist = new AvencaDataSetTableAdapters.GET_HISTORYTableAdapter();
            AvencaDataSet.GET_HISTORYDataTable h = new AvencaDataSet.GET_HISTORYDataTable();
            taHist.Fill(h, clientId);

            foreach (DataRow rows in h.Rows)
            {
                foreach (DataColumn col in h.Columns)
                {
                    output.AppendFormat("{0} ", rows[col]);
                }
                output.AppendLine();
            }
            string s = PrinterSettings.InstalledPrinters[2];
            printDocument1.PrinterSettings.PrinterName = "CAIXA";
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font headerFont = new System.Drawing.Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            Font bodyFont = new System.Drawing.Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            if(lblNome.Text.Length > 20)
                e.Graphics.DrawString(lblNome.Text.Substring(0, 18), headerFont, Brushes.Black, 15, 10);
            else e.Graphics.DrawString(lblNome.Text, headerFont, Brushes.Black, 15, 10);
            e.Graphics.DrawString(lblCPF.Text, headerFont, Brushes.Black, 15, 25);
            e.Graphics.DrawString(output.ToString(), bodyFont, Brushes.Black, 15, 45);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if(added)
                confirmAction("Tem certeza que deseja adicionar mais de um registro?", MessageBoxIcon.Warning, ADD_FIDELIDADE);
            else
            {
                mainForm.insertFidelidade(clientId);
                refreshGridView();
                added = true;
            }            
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            confirmAction("Tem certeza que deseja apagar esse registro?", MessageBoxIcon.Warning, DELETE_FIDELIDADE);
        }

        private void btnUseFidelidade_Click(object sender, EventArgs e)
        {
            int i;
            if (Int32.TryParse(lblFidelidades.Text, out i) && i > 0)
                confirmAction("Confirma a utilização do desconto?", MessageBoxIcon.Question, USE_FIDELIDADE);
            else frmMessageBox.ShowDialog(this, "Aviso", "Desculpe. O cliente ainda não acumulou dias suficientes.", MessageBoxButtons.OK, MessageBoxIcon.Information, ref mainForm.msgForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            confirmAction("Confirma cancelamento da última utilização?", MessageBoxIcon.Warning, REVERT_FIDELIDADE);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            confirmAction("Confirma a impressão?", MessageBoxIcon.Question, PRINT_HISTORY);
        }

        private void confirmAction(string text, MessageBoxIcon type, int action)
        {
            if (frmMessageBox.ShowDialog(this, "Confirmação", text, MessageBoxButtons.YesNo, type, ref mainForm.msgForm) == DialogResult.Yes)
            {
                switch(action)
                {
                    case ADD_FIDELIDADE:
                        mainForm.insertFidelidade(clientId);
                        added = false;
                        break;
                    case USE_FIDELIDADE:
                        mainForm.useFidelidade(clientId);
                        used = true;
                        break;
                    case DELETE_FIDELIDADE:
                        mainForm.deleteFidelidade(clientId);
                        break;
                    case REVERT_FIDELIDADE:
                        mainForm.revertFidelidade(clientId);
                        break;
                    case PRINT_HISTORY:
                        printHistory();
                        break;
                    default:
                        break;
                }
                fidelidadeTableAdapter.Update(avencaDataSet);
                refreshGridView();
            }
        }

        private void frmFidelidade_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.hwndFrmFidelidade = (IntPtr)0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
