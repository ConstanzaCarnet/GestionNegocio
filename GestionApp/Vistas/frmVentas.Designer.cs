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
            groupBox1 = new GroupBox();
            dgvGrilla = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            rdbCliente = new RadioButton();
            rdbMes = new RadioButton();
            rdbProducto = new RadioButton();
            cmbFormaPago = new ComboBox();
            groupBox2 = new GroupBox();
            cmdMostrar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdMostrar);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(cmbFormaPago);
            groupBox1.Controls.Add(dgvGrilla);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(740, 723);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos registrados";
            // 
            // dgvGrilla
            // 
            dgvGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrilla.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dgvGrilla.Location = new Point(40, 245);
            dgvGrilla.Name = "dgvGrilla";
            dgvGrilla.ReadOnly = true;
            dgvGrilla.RowHeadersVisible = false;
            dgvGrilla.ScrollBars = ScrollBars.Vertical;
            dgvGrilla.Size = new Size(655, 467);
            dgvGrilla.TabIndex = 36;
            // 
            // Column1
            // 
            Column1.HeaderText = "Cliente";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 200;
            // 
            // Column2
            // 
            Column2.HeaderText = "Productos";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 150;
            // 
            // Column3
            // 
            Column3.HeaderText = "Monto";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 150;
            // 
            // Column4
            // 
            Column4.HeaderText = "Fecha";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 150;
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
            // 
            // cmbFormaPago
            // 
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Location = new Point(89, 170);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(320, 26);
            cmbFormaPago.TabIndex = 41;
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
            // cmdMostrar
            // 
            cmdMostrar.BackColor = Color.Gainsboro;
            cmdMostrar.FlatStyle = FlatStyle.Popup;
            cmdMostrar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdMostrar.Location = new Point(469, 169);
            cmdMostrar.Name = "cmdMostrar";
            cmdMostrar.Size = new Size(141, 26);
            cmdMostrar.TabIndex = 43;
            cmdMostrar.Text = "MOSTRAR";
            cmdMostrar.UseVisualStyleBackColor = false;
            // 
            // frmVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(767, 746);
            Controls.Add(groupBox1);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ventas";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private ComboBox cmbFormaPago;
    }
}