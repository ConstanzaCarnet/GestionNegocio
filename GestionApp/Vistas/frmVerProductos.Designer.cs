namespace GestionApp
{
    partial class frmVerProductos
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
            dgvGrilla = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(dgvGrilla);
            grpDatos.Location = new Point(12, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(1019, 577);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Todos los productos";
            grpDatos.Enter += grpDatos_Enter;
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
            dgvGrilla.Size = new Size(977, 516);
            dgvGrilla.TabIndex = 1;
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
            // frmVerProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1043, 603);
            Controls.Add(grpDatos);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmVerProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ver productos";
            Load += frmVerProductos_Load;
            grpDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private DataGridView dgvGrilla;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn PrecioCompra;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn Stock;
    }
}