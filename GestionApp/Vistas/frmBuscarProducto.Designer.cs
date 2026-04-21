namespace GestionApp
{
    partial class frmBuscarProducto
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            grpBuscar = new GroupBox();
            cmdBuscar = new Button();
            dgvGrilla = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            txtProducto = new TextBox();
            label3 = new Label();
            grpBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            SuspendLayout();
            // 
            // grpBuscar
            // 
            grpBuscar.Controls.Add(cmdBuscar);
            grpBuscar.Controls.Add(dgvGrilla);
            grpBuscar.Controls.Add(txtProducto);
            grpBuscar.Controls.Add(label3);
            grpBuscar.Location = new Point(12, 12);
            grpBuscar.Name = "grpBuscar";
            grpBuscar.Size = new Size(960, 407);
            grpBuscar.TabIndex = 0;
            grpBuscar.TabStop = false;
            grpBuscar.Text = "Buscar";
            // 
            // cmdBuscar
            // 
            cmdBuscar.BackColor = Color.Gainsboro;
            cmdBuscar.FlatStyle = FlatStyle.Popup;
            cmdBuscar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdBuscar.Location = new Point(530, 94);
            cmdBuscar.Name = "cmdBuscar";
            cmdBuscar.Size = new Size(134, 26);
            cmdBuscar.TabIndex = 52;
            cmdBuscar.Text = "BUSCAR";
            cmdBuscar.UseVisualStyleBackColor = false;
            cmdBuscar.Click += cmdBuscar_Click;
            // 
            // dgvGrilla
            // 
            dgvGrilla.AllowUserToAddRows = false;
            dgvGrilla.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dgvGrilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrilla.Columns.AddRange(new DataGridViewColumn[] { Nombre, PrecioCompra, PrecioVenta, Stock, Categoria });
            dgvGrilla.Location = new Point(50, 155);
            dgvGrilla.Name = "dgvGrilla";
            dgvGrilla.ReadOnly = true;
            dgvGrilla.RowHeadersVisible = false;
            dgvGrilla.ScrollBars = ScrollBars.Vertical;
            dgvGrilla.Size = new Size(863, 230);
            dgvGrilla.TabIndex = 51;
            // 
            // Nombre
            // 
            Nombre.DataPropertyName = "Nombre";
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 230;
            // 
            // PrecioCompra
            // 
            PrecioCompra.DataPropertyName = "PrecioCompra";
            PrecioCompra.HeaderText = "Precio de lista";
            PrecioCompra.Name = "PrecioCompra";
            PrecioCompra.ReadOnly = true;
            PrecioCompra.Width = 160;
            // 
            // PrecioVenta
            // 
            PrecioVenta.DataPropertyName = "PrecioVenta";
            PrecioVenta.HeaderText = "Precio de venta";
            PrecioVenta.Name = "PrecioVenta";
            PrecioVenta.ReadOnly = true;
            PrecioVenta.Width = 160;
            // 
            // Stock
            // 
            Stock.DataPropertyName = "Stock";
            Stock.HeaderText = "Stock";
            Stock.Name = "Stock";
            Stock.ReadOnly = true;
            Stock.Width = 120;
            // 
            // Categoria
            // 
            Categoria.DataPropertyName = "Categoria";
            Categoria.HeaderText = "Categoría";
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            Categoria.Width = 180;
            // 
            // txtProducto
            // 
            txtProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProducto.Location = new Point(357, 46);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(307, 26);
            txtProducto.TabIndex = 50;
            // 
            // label3
            // 
            label3.Location = new Point(217, 46);
            label3.Name = "label3";
            label3.Size = new Size(134, 22);
            label3.TabIndex = 49;
            label3.Text = "Producto:";
            // 
            // frmBuscarProducto
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(984, 432);
            Controls.Add(grpBuscar);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBuscarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar producto";
            Load += frmBuscarProducto_Load;
            grpBuscar.ResumeLayout(false);
            grpBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBuscar;
        private TextBox txtProducto;
        private Label label3;
        private DataGridView dgvGrilla;
        private Button cmdBuscar;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn PrecioCompra;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn Stock;
        private DataGridViewTextBoxColumn Categoria;
    }
}