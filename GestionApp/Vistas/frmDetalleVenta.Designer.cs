namespace GestionApp
{
    partial class frmDetalleVenta
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            lblTotal = new Label();
            lblEtTotal = new Label();
            lblFecha = new Label();
            lblEtFecha = new Label();
            button2 = new Button();
            cmdEmail = new Button();
            lblCliente = new Label();
            lblEtCliente = new Label();
            dgvGrilla = new DataGridView();
            Producto = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            PrecioUnitario = new DataGridViewTextBoxColumn();
            Subtotal = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblTotal);
            groupBox1.Controls.Add(lblEtTotal);
            groupBox1.Controls.Add(lblFecha);
            groupBox1.Controls.Add(lblEtFecha);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(cmdEmail);
            groupBox1.Controls.Add(lblCliente);
            groupBox1.Controls.Add(lblEtCliente);
            groupBox1.Controls.Add(dgvGrilla);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(654, 542);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información";
            // 
            // lblTotal
            // 
            lblTotal.BorderStyle = BorderStyle.Fixed3D;
            lblTotal.FlatStyle = FlatStyle.Popup;
            lblTotal.Location = new Point(387, 409);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(250, 28);
            lblTotal.TabIndex = 46;
            // 
            // lblEtTotal
            // 
            lblEtTotal.Location = new Point(324, 417);
            lblEtTotal.Name = "lblEtTotal";
            lblEtTotal.Size = new Size(108, 20);
            lblEtTotal.TabIndex = 45;
            lblEtTotal.Text = "Total:";
            // 
            // lblFecha
            // 
            lblFecha.BorderStyle = BorderStyle.Fixed3D;
            lblFecha.FlatStyle = FlatStyle.Popup;
            lblFecha.Location = new Point(129, 92);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(250, 28);
            lblFecha.TabIndex = 44;
            // 
            // lblEtFecha
            // 
            lblEtFecha.Location = new Point(20, 100);
            lblEtFecha.Name = "lblEtFecha";
            lblEtFecha.Size = new Size(88, 20);
            lblEtFecha.TabIndex = 43;
            lblEtFecha.Text = "Fecha:";
            // 
            // button2
            // 
            button2.BackColor = Color.Gainsboro;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(20, 467);
            button2.Name = "button2";
            button2.Size = new Size(153, 53);
            button2.TabIndex = 42;
            button2.Text = "DESCARGAR PDF";
            button2.UseVisualStyleBackColor = false;
            // 
            // cmdEmail
            // 
            cmdEmail.BackColor = Color.Gainsboro;
            cmdEmail.FlatStyle = FlatStyle.Popup;
            cmdEmail.Location = new Point(484, 467);
            cmdEmail.Name = "cmdEmail";
            cmdEmail.Size = new Size(153, 53);
            cmdEmail.TabIndex = 40;
            cmdEmail.Text = "MANDAR MENSAJE";
            cmdEmail.UseVisualStyleBackColor = false;
            cmdEmail.Click += cmdEmail_Click;
            // 
            // lblCliente
            // 
            lblCliente.BorderStyle = BorderStyle.Fixed3D;
            lblCliente.FlatStyle = FlatStyle.Popup;
            lblCliente.Location = new Point(129, 52);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(250, 28);
            lblCliente.TabIndex = 39;
            // 
            // lblEtCliente
            // 
            lblEtCliente.Location = new Point(20, 53);
            lblEtCliente.Name = "lblEtCliente";
            lblEtCliente.Size = new Size(108, 20);
            lblEtCliente.TabIndex = 38;
            lblEtCliente.Text = "Cliente:";
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
            dgvGrilla.ColumnHeadersHeight = 35;
            dgvGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvGrilla.Columns.AddRange(new DataGridViewColumn[] { Producto, Cantidad, PrecioUnitario, Subtotal });
            dgvGrilla.Location = new Point(20, 149);
            dgvGrilla.Name = "dgvGrilla";
            dgvGrilla.ReadOnly = true;
            dgvGrilla.RowHeadersVisible = false;
            dgvGrilla.ScrollBars = ScrollBars.Vertical;
            dgvGrilla.Size = new Size(617, 235);
            dgvGrilla.TabIndex = 37;
            // 
            // Producto
            // 
            Producto.DataPropertyName = "Producto";
            Producto.HeaderText = "Producto";
            Producto.Name = "Producto";
            Producto.ReadOnly = true;
            Producto.Width = 160;
            // 
            // Cantidad
            // 
            Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            Cantidad.DefaultCellStyle = dataGridViewCellStyle2;
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            Cantidad.Width = 150;
            // 
            // PrecioUnitario
            // 
            PrecioUnitario.DataPropertyName = "PrecioUnitario";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            PrecioUnitario.DefaultCellStyle = dataGridViewCellStyle3;
            PrecioUnitario.HeaderText = "Precio U.";
            PrecioUnitario.Name = "PrecioUnitario";
            PrecioUnitario.ReadOnly = true;
            PrecioUnitario.Width = 150;
            // 
            // Subtotal
            // 
            Subtotal.DataPropertyName = "Subtotal";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            Subtotal.DefaultCellStyle = dataGridViewCellStyle4;
            Subtotal.HeaderText = "Subtotal";
            Subtotal.Name = "Subtotal";
            Subtotal.ReadOnly = true;
            Subtotal.Width = 150;
            // 
            // frmDetalleVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(677, 567);
            Controls.Add(groupBox1);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmDetalleVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de la venta";
            Load += frmDetalleVenta_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvGrilla;
        private Label lblCliente;
        private Label lblEtCliente;
        private Button button2;
        private Button cmdEmail;
        private Label lblTotal;
        private Label lblEtTotal;
        private Label lblFecha;
        private Label lblEtFecha;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn PrecioUnitario;
        private DataGridViewTextBoxColumn Subtotal;
    }
}