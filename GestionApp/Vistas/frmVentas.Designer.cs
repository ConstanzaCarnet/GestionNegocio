namespace GestionApp
{
    partial class frmVentas
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dtpPeriodo = new DateTimePicker();
            cmdMostrar = new Button();
            groupBox2 = new GroupBox();
            rdbCliente = new RadioButton();
            rdbMes = new RadioButton();
            rdbProducto = new RadioButton();
            cmbOpciones = new ComboBox();
            dgvGrilla = new DataGridView();
            Cliente = new DataGridViewTextBoxColumn();
            Monto = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            cmdVerDetalle = new DataGridViewButtonColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpPeriodo);
            groupBox1.Controls.Add(cmdMostrar);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(cmbOpciones);
            groupBox1.Controls.Add(dgvGrilla);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(740, 743);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos registrados";
            // 
            // dtpPeriodo
            // 
            dtpPeriodo.CustomFormat = "MMMM yyyy";
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.Location = new Point(89, 216);
            dtpPeriodo.Name = "dtpPeriodo";
            dtpPeriodo.ShowUpDown = true;
            dtpPeriodo.Size = new Size(348, 26);
            dtpPeriodo.TabIndex = 44;
            // 
            // cmdMostrar
            // 
            cmdMostrar.BackColor = Color.Gainsboro;
            cmdMostrar.FlatStyle = FlatStyle.Popup;
            cmdMostrar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdMostrar.Location = new Point(510, 173);
            cmdMostrar.Name = "cmdMostrar";
            cmdMostrar.Size = new Size(141, 26);
            cmdMostrar.TabIndex = 43;
            cmdMostrar.Text = "MOSTRAR";
            cmdMostrar.UseVisualStyleBackColor = false;
            cmdMostrar.Click += cmdMostrar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rdbCliente);
            groupBox2.Controls.Add(rdbMes);
            groupBox2.Controls.Add(rdbProducto);
            groupBox2.Location = new Point(41, 37);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(655, 93);
            groupBox2.TabIndex = 42;
            groupBox2.TabStop = false;
            groupBox2.Text = "Mostrar por...";
            // 
            // rdbCliente
            // 
            rdbCliente.AutoSize = true;
            rdbCliente.Location = new Point(48, 40);
            rdbCliente.Name = "rdbCliente";
            rdbCliente.Size = new Size(68, 22);
            rdbCliente.TabIndex = 38;
            rdbCliente.TabStop = true;
            rdbCliente.Text = "Cliente";
            rdbCliente.UseVisualStyleBackColor = true;
            rdbCliente.CheckedChanged += rdbCliente_CheckedChanged;
            // 
            // rdbMes
            // 
            rdbMes.AutoSize = true;
            rdbMes.Location = new Point(273, 40);
            rdbMes.Name = "rdbMes";
            rdbMes.Size = new Size(53, 22);
            rdbMes.TabIndex = 39;
            rdbMes.TabStop = true;
            rdbMes.Text = "Mes";
            rdbMes.UseVisualStyleBackColor = true;
            rdbMes.CheckedChanged += rdbMes_CheckedChanged;
            // 
            // rdbProducto
            // 
            rdbProducto.AutoSize = true;
            rdbProducto.Location = new Point(515, 40);
            rdbProducto.Name = "rdbProducto";
            rdbProducto.Size = new Size(83, 22);
            rdbProducto.TabIndex = 40;
            rdbProducto.TabStop = true;
            rdbProducto.Text = "Producto";
            rdbProducto.UseVisualStyleBackColor = true;
            rdbProducto.CheckedChanged += rdbProducto_CheckedChanged;
            // 
            // cmbOpciones
            // 
            cmbOpciones.FormattingEnabled = true;
            cmbOpciones.Location = new Point(89, 174);
            cmbOpciones.Name = "cmbOpciones";
            cmbOpciones.Size = new Size(348, 26);
            cmbOpciones.TabIndex = 41;
            // 
            // dgvGrilla
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvGrilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvGrilla.ColumnHeadersHeight = 40;
            dgvGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvGrilla.Columns.AddRange(new DataGridViewColumn[] { Cliente, Monto, Fecha, cmdVerDetalle });
            dgvGrilla.Location = new Point(41, 270);
            dgvGrilla.Name = "dgvGrilla";
            dgvGrilla.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvGrilla.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvGrilla.RowHeadersVisible = false;
            dgvGrilla.RowHeadersWidth = 45;
            dgvGrilla.ScrollBars = ScrollBars.Vertical;
            dgvGrilla.Size = new Size(655, 467);
            dgvGrilla.TabIndex = 36;
            dgvGrilla.CellContentClick += dgvGrilla_CellContentClick;
            // 
            // Cliente
            // 
            Cliente.DataPropertyName = "Cliente";
            Cliente.HeaderText = "Cliente";
            Cliente.Name = "Cliente";
            Cliente.ReadOnly = true;
            Cliente.Width = 200;
            // 
            // Monto
            // 
            Monto.DataPropertyName = "Total";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            Monto.DefaultCellStyle = dataGridViewCellStyle2;
            Monto.HeaderText = "Monto";
            Monto.Name = "Monto";
            Monto.ReadOnly = true;
            Monto.Width = 170;
            // 
            // Fecha
            // 
            Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            Fecha.DefaultCellStyle = dataGridViewCellStyle3;
            Fecha.HeaderText = "Fecha";
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;
            Fecha.Width = 170;
            // 
            // cmdVerDetalle
            // 
            cmdVerDetalle.DataPropertyName = "cmdVerDetalle";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(192, 255, 255);
            cmdVerDetalle.DefaultCellStyle = dataGridViewCellStyle4;
            cmdVerDetalle.HeaderText = "Detalle";
            cmdVerDetalle.Name = "cmdVerDetalle";
            cmdVerDetalle.ReadOnly = true;
            cmdVerDetalle.UseColumnTextForButtonValue = true;
            // 
            // frmVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(767, 767);
            Controls.Add(groupBox1);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ventas";
            Load += frmVentas_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvGrilla;
        private RadioButton rdbProducto;
        private RadioButton rdbMes;
        private RadioButton rdbCliente;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Button cmdMostrar;
        private GroupBox groupBox2;
        private ComboBox cmbOpciones;
        private DateTimePicker dtpPeriodo;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn Monto;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewButtonColumn cmdVerDetalle;
    }
}