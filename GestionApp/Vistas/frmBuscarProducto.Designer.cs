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
            grpBuscar = new GroupBox();
            txtCantidad = new TextBox();
            label3 = new Label();
            dgvGrilla = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            cmdBuscar = new Button();
            grpBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            SuspendLayout();
            // 
            // grpBuscar
            // 
            grpBuscar.Controls.Add(cmdBuscar);
            grpBuscar.Controls.Add(dgvGrilla);
            grpBuscar.Controls.Add(txtCantidad);
            grpBuscar.Controls.Add(label3);
            grpBuscar.Location = new Point(12, 12);
            grpBuscar.Name = "grpBuscar";
            grpBuscar.Size = new Size(960, 407);
            grpBuscar.TabIndex = 0;
            grpBuscar.TabStop = false;
            grpBuscar.Text = "Buscar";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(417, 46);
            txtCantidad.Multiline = true;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(247, 23);
            txtCantidad.TabIndex = 50;
            // 
            // label3
            // 
            label3.Location = new Point(217, 49);
            label3.Name = "label3";
            label3.Size = new Size(194, 22);
            label3.TabIndex = 49;
            label3.Text = "Producto/tipo de producto:";
            // 
            // dgvGrilla
            // 
            dgvGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrilla.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            dgvGrilla.Location = new Point(22, 152);
            dgvGrilla.Name = "dgvGrilla";
            dgvGrilla.ReadOnly = true;
            dgvGrilla.RowHeadersVisible = false;
            dgvGrilla.ScrollBars = ScrollBars.Vertical;
            dgvGrilla.Size = new Size(918, 230);
            dgvGrilla.TabIndex = 51;
            // 
            // Column1
            // 
            Column1.HeaderText = "Nombre";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 200;
            // 
            // Column2
            // 
            Column2.HeaderText = "Precio de lista";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 150;
            // 
            // Column3
            // 
            Column3.HeaderText = "Precio de venta";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 150;
            // 
            // Column4
            // 
            Column4.HeaderText = "Stock";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 120;
            // 
            // Column5
            // 
            Column5.HeaderText = "Estado";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 130;
            // 
            // Column6
            // 
            Column6.HeaderText = "Categoría";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 160;
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
            grpBuscar.ResumeLayout(false);
            grpBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBuscar;
        private TextBox txtCantidad;
        private Label label3;
        private DataGridView dgvGrilla;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private Button cmdBuscar;
    }
}