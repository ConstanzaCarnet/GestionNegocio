namespace GestionApp
{
    partial class frmNuevoProducto
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
            grpDatos = new GroupBox();
            cmdAgregar = new Button();
            cmbCategoria = new ComboBox();
            txtPCompra = new TextBox();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtStock = new TextBox();
            txtPVenta = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            dgvGrilla = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            grpDatos.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(cmdAgregar);
            grpDatos.Controls.Add(cmbCategoria);
            grpDatos.Controls.Add(txtPCompra);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(txtDescripcion);
            grpDatos.Controls.Add(txtStock);
            grpDatos.Controls.Add(txtPVenta);
            grpDatos.Controls.Add(label6);
            grpDatos.Controls.Add(label5);
            grpDatos.Controls.Add(label4);
            grpDatos.Controls.Add(label3);
            grpDatos.Controls.Add(label2);
            grpDatos.Controls.Add(label1);
            grpDatos.Location = new Point(14, 14);
            grpDatos.Margin = new Padding(3, 4, 3, 4);
            grpDatos.Name = "grpDatos";
            grpDatos.Padding = new Padding(3, 4, 3, 4);
            grpDatos.Size = new Size(1019, 290);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Cargar datos";
            // 
            // cmdAgregar
            // 
            cmdAgregar.BackColor = Color.Gainsboro;
            cmdAgregar.Enabled = false;
            cmdAgregar.FlatStyle = FlatStyle.Popup;
            cmdAgregar.Location = new Point(707, 230);
            cmdAgregar.Name = "cmdAgregar";
            cmdAgregar.Size = new Size(210, 42);
            cmdAgregar.TabIndex = 14;
            cmdAgregar.Text = "AGREGAR";
            cmdAgregar.UseVisualStyleBackColor = false;
            cmdAgregar.Click += cmdAgregar_Click;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(168, 107);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(284, 26);
            cmbCategoria.TabIndex = 13;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            // 
            // txtPCompra
            // 
            txtPCompra.Location = new Point(191, 69);
            txtPCompra.Multiline = true;
            txtPCompra.Name = "txtPCompra";
            txtPCompra.Size = new Size(261, 23);
            txtPCompra.TabIndex = 12;
            txtPCompra.TextChanged += txtPCompra_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(168, 35);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(284, 23);
            txtNombre.TabIndex = 11;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(168, 149);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(749, 61);
            txtDescripcion.TabIndex = 10;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(591, 35);
            txtStock.Multiline = true;
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(326, 23);
            txtStock.TabIndex = 9;
            txtStock.TextChanged += txtStock_TextChanged;
            // 
            // txtPVenta
            // 
            txtPVenta.Location = new Point(646, 69);
            txtPVenta.Multiline = true;
            txtPVenta.Name = "txtPVenta";
            txtPVenta.Size = new Size(271, 23);
            txtPVenta.TabIndex = 8;
            txtPVenta.TextChanged += txtPVenta_TextChanged;
            // 
            // label6
            // 
            label6.Location = new Point(61, 72);
            label6.Name = "label6";
            label6.Size = new Size(141, 28);
            label6.TabIndex = 6;
            label6.Text = "Precio de compra:";
            // 
            // label5
            // 
            label5.Location = new Point(516, 72);
            label5.Name = "label5";
            label5.Size = new Size(141, 23);
            label5.TabIndex = 5;
            label5.Text = "Precio de venta:";
            // 
            // label4
            // 
            label4.Location = new Point(61, 110);
            label4.Name = "label4";
            label4.Size = new Size(103, 28);
            label4.TabIndex = 4;
            label4.Text = "Categoría:";
            // 
            // label3
            // 
            label3.Location = new Point(516, 38);
            label3.Name = "label3";
            label3.Size = new Size(64, 25);
            label3.TabIndex = 3;
            label3.Text = "Stock:";
            // 
            // label2
            // 
            label2.Location = new Point(59, 149);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 2;
            label2.Text = "Descripción:";
            // 
            // label1
            // 
            label1.Location = new Point(61, 38);
            label1.Name = "label1";
            label1.Size = new Size(141, 23);
            label1.TabIndex = 1;
            label1.Text = "Nombre:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvGrilla);
            groupBox1.Location = new Point(12, 311);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1019, 522);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Todos los productos";
            // 
            // dgvGrilla
            // 
            dgvGrilla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrilla.Columns.AddRange(new DataGridViewColumn[] { Nombre, Descripcion, PrecioCompra, PrecioVenta, Stock });
            dgvGrilla.Location = new Point(24, 36);
            dgvGrilla.Name = "dgvGrilla";
            dgvGrilla.ReadOnly = true;
            dgvGrilla.RowHeadersVisible = false;
            dgvGrilla.ScrollBars = ScrollBars.Vertical;
            dgvGrilla.Size = new Size(977, 470);
            dgvGrilla.TabIndex = 1;
            dgvGrilla.CellContentClick += dgvGrilla_CellContentClick;
            // 
            // Nombre
            // 
            Nombre.DataPropertyName = "Nombre";
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 220;
            // 
            // Descripcion
            // 
            Descripcion.DataPropertyName = "Descripcion";
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Descripcion.DefaultCellStyle = dataGridViewCellStyle1;
            Descripcion.HeaderText = "Descripción";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            Descripcion.Width = 300;
            // 
            // PrecioCompra
            // 
            PrecioCompra.DataPropertyName = "PrecioCompra";
            PrecioCompra.HeaderText = "Precio de lista";
            PrecioCompra.Name = "PrecioCompra";
            PrecioCompra.ReadOnly = true;
            PrecioCompra.Width = 150;
            // 
            // PrecioVenta
            // 
            PrecioVenta.DataPropertyName = "PrecioVenta";
            PrecioVenta.HeaderText = "Precio de venta";
            PrecioVenta.Name = "PrecioVenta";
            PrecioVenta.ReadOnly = true;
            PrecioVenta.Width = 150;
            // 
            // Stock
            // 
            Stock.DataPropertyName = "Stock";
            Stock.HeaderText = "Stock";
            Stock.Name = "Stock";
            Stock.ReadOnly = true;
            Stock.Width = 150;
            // 
            // frmNuevoProducto
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1043, 845);
            Controls.Add(groupBox1);
            Controls.Add(grpDatos);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNuevoProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nuevo producto";
            Load += frmNuevoProducto_Load;
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtPCompra;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtStock;
        private TextBox txtPVenta;
        private ComboBox cmbCategoria;
        private Button cmdAgregar;
        private GroupBox groupBox1;
        private DataGridView dgvGrilla;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn PrecioCompra;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn Stock;
    }
}