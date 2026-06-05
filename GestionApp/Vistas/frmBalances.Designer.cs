namespace GestionApp.Vistas
{
    partial class frmBalances
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
            groupBox1 = new GroupBox();
            rdbProductos = new RadioButton();
            rdbTendencia = new RadioButton();
            rdbMetodos = new RadioButton();
            label2 = new Label();
            label1 = new Label();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            cmdFiltrar = new Button();
            tblyBalance = new TableLayoutPanel();
            dgvListar = new DataGridView();
            panelGrafico = new Panel();
            cmdDescargar = new Button();
            cmdExcel = new Button();
            cmdReiniciar = new Button();
            groupBox1.SuspendLayout();
            tblyBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListar).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdReiniciar);
            groupBox1.Controls.Add(rdbProductos);
            groupBox1.Controls.Add(rdbTendencia);
            groupBox1.Controls.Add(rdbMetodos);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dtpDesde);
            groupBox1.Controls.Add(dtpHasta);
            groupBox1.Controls.Add(cmdFiltrar);
            groupBox1.Controls.Add(tblyBalance);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1167, 705);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ver balances";
            // 
            // rdbProductos
            // 
            rdbProductos.AutoSize = true;
            rdbProductos.Enabled = false;
            rdbProductos.Location = new Point(817, 160);
            rdbProductos.Name = "rdbProductos";
            rdbProductos.Size = new Size(101, 22);
            rdbProductos.TabIndex = 52;
            rdbProductos.TabStop = true;
            rdbProductos.Text = "Productos";
            rdbProductos.UseVisualStyleBackColor = true;
            rdbProductos.CheckedChanged += rdbProductos_CheckedChanged;
            // 
            // rdbTendencia
            // 
            rdbTendencia.AutoSize = true;
            rdbTendencia.Enabled = false;
            rdbTendencia.Location = new Point(989, 160);
            rdbTendencia.Name = "rdbTendencia";
            rdbTendencia.Size = new Size(98, 22);
            rdbTendencia.TabIndex = 51;
            rdbTendencia.TabStop = true;
            rdbTendencia.Text = "Tendencia";
            rdbTendencia.UseVisualStyleBackColor = true;
            rdbTendencia.CheckedChanged += rdbTendencia_CheckedChanged;
            // 
            // rdbMetodos
            // 
            rdbMetodos.AutoSize = true;
            rdbMetodos.Enabled = false;
            rdbMetodos.Location = new Point(594, 160);
            rdbMetodos.Name = "rdbMetodos";
            rdbMetodos.Size = new Size(156, 22);
            rdbMetodos.TabIndex = 50;
            rdbMetodos.TabStop = true;
            rdbMetodos.Text = "Metodos de pago";
            rdbMetodos.UseVisualStyleBackColor = true;
            rdbMetodos.CheckedChanged += rdbMetodos_CheckedChanged;
            // 
            // label2
            // 
            label2.Location = new Point(644, 43);
            label2.Name = "label2";
            label2.Size = new Size(78, 26);
            label2.TabIndex = 49;
            label2.Text = "Hasta:";
            // 
            // label1
            // 
            label1.Location = new Point(87, 43);
            label1.Name = "label1";
            label1.Size = new Size(78, 26);
            label1.TabIndex = 48;
            label1.Text = "Desde:";
            // 
            // dtpDesde
            // 
            dtpDesde.CustomFormat = "MMMM yyyy";
            dtpDesde.Format = DateTimePickerFormat.Custom;
            dtpDesde.Location = new Point(171, 37);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.ShowUpDown = true;
            dtpDesde.Size = new Size(328, 26);
            dtpDesde.TabIndex = 47;
            dtpDesde.ValueChanged += dtpDesde_ValueChanged;
            // 
            // dtpHasta
            // 
            dtpHasta.CustomFormat = "MMMM yyyy";
            dtpHasta.Format = DateTimePickerFormat.Custom;
            dtpHasta.Location = new Point(728, 37);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.ShowUpDown = true;
            dtpHasta.Size = new Size(328, 26);
            dtpHasta.TabIndex = 46;
            // 
            // cmdFiltrar
            // 
            cmdFiltrar.BackColor = Color.Gainsboro;
            cmdFiltrar.FlatStyle = FlatStyle.Popup;
            cmdFiltrar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdFiltrar.Location = new Point(915, 88);
            cmdFiltrar.Name = "cmdFiltrar";
            cmdFiltrar.Size = new Size(141, 26);
            cmdFiltrar.TabIndex = 45;
            cmdFiltrar.Text = "MOSTRAR";
            cmdFiltrar.UseVisualStyleBackColor = false;
            cmdFiltrar.Click += cmdFiltrar_Click;
            // 
            // tblyBalance
            // 
            tblyBalance.ColumnCount = 2;
            tblyBalance.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblyBalance.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblyBalance.Controls.Add(dgvListar, 0, 0);
            tblyBalance.Controls.Add(panelGrafico, 1, 0);
            tblyBalance.ImeMode = ImeMode.On;
            tblyBalance.Location = new Point(46, 207);
            tblyBalance.Name = "tblyBalance";
            tblyBalance.RowCount = 1;
            tblyBalance.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblyBalance.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblyBalance.Size = new Size(1064, 435);
            tblyBalance.TabIndex = 0;
            // 
            // dgvListar
            // 
            dgvListar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvListar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListar.ImeMode = ImeMode.NoControl;
            dgvListar.Location = new Point(3, 3);
            dgvListar.Name = "dgvListar";
            dgvListar.RowHeadersVisible = false;
            dgvListar.ScrollBars = ScrollBars.Vertical;
            dgvListar.Size = new Size(526, 426);
            dgvListar.TabIndex = 0;
            // 
            // panelGrafico
            // 
            panelGrafico.Location = new Point(535, 3);
            panelGrafico.Name = "panelGrafico";
            panelGrafico.Size = new Size(526, 426);
            panelGrafico.TabIndex = 1;
            // 
            // cmdDescargar
            // 
            cmdDescargar.BackColor = Color.Gainsboro;
            cmdDescargar.FlatStyle = FlatStyle.Popup;
            cmdDescargar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdDescargar.Location = new Point(1001, 732);
            cmdDescargar.Name = "cmdDescargar";
            cmdDescargar.Size = new Size(178, 26);
            cmdDescargar.TabIndex = 50;
            cmdDescargar.Text = "DESCARGAR ARCHIVO";
            cmdDescargar.UseVisualStyleBackColor = false;
            cmdDescargar.Click += cmdDescargar_Click;
            // 
            // cmdExcel
            // 
            cmdExcel.BackColor = Color.Gainsboro;
            cmdExcel.FlatStyle = FlatStyle.Popup;
            cmdExcel.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdExcel.Location = new Point(740, 732);
            cmdExcel.Name = "cmdExcel";
            cmdExcel.Size = new Size(178, 26);
            cmdExcel.TabIndex = 51;
            cmdExcel.Text = "EXPORTAR EXCEL";
            cmdExcel.UseVisualStyleBackColor = false;
            cmdExcel.Click += cmdExcel_Click;
            // 
            // cmdReiniciar
            // 
            cmdReiniciar.BackColor = Color.Gainsboro;
            cmdReiniciar.FlatStyle = FlatStyle.Popup;
            cmdReiniciar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdReiniciar.Location = new Point(49, 660);
            cmdReiniciar.Name = "cmdReiniciar";
            cmdReiniciar.Size = new Size(178, 26);
            cmdReiniciar.TabIndex = 53;
            cmdReiniciar.Text = "REINICIAR";
            cmdReiniciar.UseVisualStyleBackColor = false;
            cmdReiniciar.Click += cmdReiniciar_Click;
            // 
            // frmBalances
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1191, 767);
            Controls.Add(cmdExcel);
            Controls.Add(cmdDescargar);
            Controls.Add(groupBox1);
            Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBalances";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Balances";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tblyBalance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvListar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel tblyBalance;
        private DataGridView dgvListar;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button cmdFiltrar;
        private Label label1;
        private Label label2;
        private Button cmdDescargar;
        private Button cmdExcel;
        private Panel panelGrafico;
        private RadioButton rdbMetodos;
        private RadioButton rdbTendencia;
        private RadioButton rdbProductos;
        private Button cmdReiniciar;
    }
}