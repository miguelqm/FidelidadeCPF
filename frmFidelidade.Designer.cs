namespace FidelidadeCPF
{
    partial class frmFidelidade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFidelidade));
            this.dgvFidelidade = new System.Windows.Forms.DataGridView();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblCPF = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnUseFidelidade = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFidelidades = new System.Windows.Forms.Label();
            this.btnRevert = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLastUse = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.fidelidadeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.avencaDataSet = new FidelidadeCPF.AvencaDataSet();
            this.fidelidadeTableAdapter = new FidelidadeCPF.AvencaDataSetTableAdapters.FidelidadeTableAdapter();
            this.rowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weekday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataHoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdFuncionarioCarimbo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdFuncionarioUso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFidelidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fidelidadeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avencaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFidelidade
            // 
            this.dgvFidelidade.AllowUserToAddRows = false;
            this.dgvFidelidade.AllowUserToDeleteRows = false;
            this.dgvFidelidade.AllowUserToResizeColumns = false;
            this.dgvFidelidade.AllowUserToResizeRows = false;
            this.dgvFidelidade.AutoGenerateColumns = false;
            this.dgvFidelidade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFidelidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFidelidade.ColumnHeadersVisible = false;
            this.dgvFidelidade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowNumber,
            this.Weekday,
            this.dataHoraDataGridViewTextBoxColumn,
            this.IdFuncionarioCarimbo,
            this.IdFuncionarioUso});
            this.dgvFidelidade.DataSource = this.fidelidadeBindingSource;
            this.dgvFidelidade.Enabled = false;
            this.dgvFidelidade.Location = new System.Drawing.Point(12, 197);
            this.dgvFidelidade.MultiSelect = false;
            this.dgvFidelidade.Name = "dgvFidelidade";
            this.dgvFidelidade.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFidelidade.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFidelidade.RowHeadersVisible = false;
            this.dgvFidelidade.RowHeadersWidth = 10;
            this.dgvFidelidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFidelidade.ShowEditingIcon = false;
            this.dgvFidelidade.Size = new System.Drawing.Size(299, 223);
            this.dgvFidelidade.TabIndex = 0;
            this.dgvFidelidade.Tag = "0 3";
            // 
            // lblNome
            // 
            this.lblNome.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblNome.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.ForeColor = System.Drawing.Color.White;
            this.lblNome.Location = new System.Drawing.Point(9, 20);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(302, 20);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "MIGUEL QUENTAL MORAES";
            // 
            // lblCPF
            // 
            this.lblCPF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPF.Location = new System.Drawing.Point(9, 59);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(302, 20);
            this.lblCPF.TabIndex = 3;
            this.lblCPF.Text = "000.000.000-00";
            this.lblCPF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 426);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(54, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.Location = new System.Drawing.Point(316, 257);
            this.btnPlus.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(36, 40);
            this.btnPlus.TabIndex = 0;
            this.btnPlus.TabStop = false;
            this.btnPlus.Text = "+";
            this.btnPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinus.Location = new System.Drawing.Point(316, 297);
            this.btnMinus.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(36, 40);
            this.btnMinus.TabIndex = 7;
            this.btnMinus.Text = "-";
            this.btnMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnUseFidelidade
            // 
            this.btnUseFidelidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnUseFidelidade.ForeColor = System.Drawing.Color.Silver;
            this.btnUseFidelidade.Location = new System.Drawing.Point(165, 426);
            this.btnUseFidelidade.Name = "btnUseFidelidade";
            this.btnUseFidelidade.Size = new System.Drawing.Size(146, 31);
            this.btnUseFidelidade.TabIndex = 8;
            this.btnUseFidelidade.Text = "Utilizar Fidelidade";
            this.btnUseFidelidade.UseVisualStyleBackColor = true;
            this.btnUseFidelidade.Click += new System.EventHandler(this.btnUseFidelidade_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Descontos Acumulados:";
            // 
            // lblFidelidades
            // 
            this.lblFidelidades.AutoSize = true;
            this.lblFidelidades.BackColor = System.Drawing.Color.Black;
            this.lblFidelidades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFidelidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFidelidades.ForeColor = System.Drawing.Color.Yellow;
            this.lblFidelidades.Location = new System.Drawing.Point(186, 163);
            this.lblFidelidades.Name = "lblFidelidades";
            this.lblFidelidades.Size = new System.Drawing.Size(143, 26);
            this.lblFidelidades.TabIndex = 12;
            this.lblFidelidades.Text = "lblFidelidades";
            // 
            // btnRevert
            // 
            this.btnRevert.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevert.Location = new System.Drawing.Point(12, 455);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(123, 23);
            this.btnRevert.TabIndex = 13;
            this.btnRevert.Text = "Cancelar Último Desconto";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "CPF:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nome:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Empresa:";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.Location = new System.Drawing.Point(9, 97);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(302, 20);
            this.lblEmpresa.TabIndex = 17;
            this.lblEmpresa.Text = "lblEmpresa";
            this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Última utilização:";
            // 
            // lblLastUse
            // 
            this.lblLastUse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLastUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUse.Location = new System.Drawing.Point(9, 135);
            this.lblLastUse.Name = "lblLastUse";
            this.lblLastUse.Size = new System.Drawing.Size(302, 20);
            this.lblLastUse.TabIndex = 19;
            this.lblLastUse.Text = "000.000.000-00";
            this.lblLastUse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(327, 464);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(25, 19);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // fidelidadeBindingSource
            // 
            this.fidelidadeBindingSource.DataMember = "Fidelidade";
            this.fidelidadeBindingSource.DataSource = this.avencaDataSet;
            // 
            // avencaDataSet
            // 
            this.avencaDataSet.DataSetName = "AvencaDataSet";
            this.avencaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fidelidadeTableAdapter
            // 
            this.fidelidadeTableAdapter.ClearBeforeFill = true;
            // 
            // rowNumber
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.rowNumber.DefaultCellStyle = dataGridViewCellStyle1;
            this.rowNumber.FillWeight = 39.88686F;
            this.rowNumber.HeaderText = "RowNumber";
            this.rowNumber.Name = "rowNumber";
            this.rowNumber.ReadOnly = true;
            this.rowNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rowNumber.Width = 25;
            // 
            // Weekday
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Weekday.DefaultCellStyle = dataGridViewCellStyle2;
            this.Weekday.FillWeight = 117.6663F;
            this.Weekday.HeaderText = "Weekday";
            this.Weekday.Name = "Weekday";
            this.Weekday.ReadOnly = true;
            this.Weekday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataHoraDataGridViewTextBoxColumn
            // 
            this.dataHoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataHoraDataGridViewTextBoxColumn.DataPropertyName = "DataHora";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataHoraDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataHoraDataGridViewTextBoxColumn.FillWeight = 196.0109F;
            this.dataHoraDataGridViewTextBoxColumn.HeaderText = "DataHora";
            this.dataHoraDataGridViewTextBoxColumn.MinimumWidth = 120;
            this.dataHoraDataGridViewTextBoxColumn.Name = "dataHoraDataGridViewTextBoxColumn";
            this.dataHoraDataGridViewTextBoxColumn.ReadOnly = true;
            this.dataHoraDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // IdFuncionarioCarimbo
            // 
            this.IdFuncionarioCarimbo.DataPropertyName = "IdFuncionarioCarimbo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IdFuncionarioCarimbo.DefaultCellStyle = dataGridViewCellStyle4;
            this.IdFuncionarioCarimbo.HeaderText = "IdFuncionarioCarimbo";
            this.IdFuncionarioCarimbo.Name = "IdFuncionarioCarimbo";
            this.IdFuncionarioCarimbo.ReadOnly = true;
            this.IdFuncionarioCarimbo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IdFuncionarioCarimbo.Width = 25;
            // 
            // IdFuncionarioUso
            // 
            this.IdFuncionarioUso.DataPropertyName = "IdFuncionarioUso";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IdFuncionarioUso.DefaultCellStyle = dataGridViewCellStyle5;
            this.IdFuncionarioUso.HeaderText = "IdFuncionarioUso";
            this.IdFuncionarioUso.Name = "IdFuncionarioUso";
            this.IdFuncionarioUso.ReadOnly = true;
            this.IdFuncionarioUso.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IdFuncionarioUso.Width = 25;
            // 
            // frmFidelidade
            // 
            this.AcceptButton = this.btnPlus;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 487);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLastUse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.lblFidelidades);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUseFidelidade);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.dgvFidelidade);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmFidelidade";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fidelidade";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFidelidade_FormClosed);
            this.Load += new System.EventHandler(this.frmFidelidade_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmFidelidade_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFidelidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fidelidadeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avencaDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFidelidade;
        private AvencaDataSet avencaDataSet;
        private AvencaDataSetTableAdapters.FidelidadeTableAdapter fidelidadeTableAdapter;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCPF;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnUseFidelidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFidelidades;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLastUse;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.BindingSource fidelidadeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weekday;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataHoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFuncionarioCarimbo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFuncionarioUso;
    }
}