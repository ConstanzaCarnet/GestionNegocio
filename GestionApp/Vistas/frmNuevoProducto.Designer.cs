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
            grpDatos.SuspendLayout();
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
            grpDatos.Size = new Size(789, 389);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Cargar datos";
            // 
            // cmdAgregar
            // 
            cmdAgregar.BackColor = Color.Gainsboro;
            cmdAgregar.Enabled = false;
            cmdAgregar.FlatStyle = FlatStyle.Popup;
            cmdAgregar.Location = new Point(144, 319);
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
            cmbCategoria.Location = new Point(144, 126);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(224, 26);
            cmbCategoria.TabIndex = 13;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            // 
            // txtPCompra
            // 
            txtPCompra.Location = new Point(205, 85);
            txtPCompra.Multiline = true;
            txtPCompra.Name = "txtPCompra";
            txtPCompra.Size = new Size(163, 23);
            txtPCompra.TabIndex = 12;
            txtPCompra.TextChanged += txtPCompra_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(144, 46);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(224, 23);
            txtNombre.TabIndex = 11;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(144, 177);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(594, 108);
            txtDescripcion.TabIndex = 10;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(484, 46);
            txtStock.Multiline = true;
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(254, 23);
            txtStock.TabIndex = 9;
            txtStock.TextChanged += txtStock_TextChanged;
            // 
            // txtPVenta
            // 
            txtPVenta.Location = new Point(561, 85);
            txtPVenta.Multiline = true;
            txtPVenta.Name = "txtPVenta";
            txtPVenta.Size = new Size(177, 23);
            txtPVenta.TabIndex = 8;
            txtPVenta.TextChanged += txtPVenta_TextChanged;
            // 
            // label6
            // 
            label6.Location = new Point(44, 85);
            label6.Name = "label6";
            label6.Size = new Size(141, 28);
            label6.TabIndex = 6;
            label6.Text = "Precio de compra:";
            // 
            // label5
            // 
            label5.Location = new Point(414, 85);
            label5.Name = "label5";
            label5.Size = new Size(141, 28);
            label5.TabIndex = 5;
            label5.Text = "Precio de venta:";
            // 
            // label4
            // 
            label4.Location = new Point(44, 129);
            label4.Name = "label4";
            label4.Size = new Size(103, 28);
            label4.TabIndex = 4;
            label4.Text = "Categoría:";
            // 
            // label3
            // 
            label3.Location = new Point(414, 46);
            label3.Name = "label3";
            label3.Size = new Size(64, 28);
            label3.TabIndex = 3;
            label3.Text = "Stock:";
            // 
            // label2
            // 
            label2.Location = new Point(44, 177);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 2;
            label2.Text = "Descripción:";
            // 
            // label1
            // 
            label1.Location = new Point(44, 46);
            label1.Name = "label1";
            label1.Size = new Size(141, 28);
            label1.TabIndex = 1;
            label1.Text = "Nombre:";
            // 
            // frmNuevoProducto
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(817, 413);
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
    }
}