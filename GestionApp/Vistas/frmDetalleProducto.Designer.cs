namespace GestionApp
{
    partial class frmDetalleProducto
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
            cmdGuardar = new Button();
            cmdEliminar = new Button();
            cmdModificar = new Button();
            cbxCategorias = new ComboBox();
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
            cmdEmail = new Button();
            grpDatos.SuspendLayout();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(cmdGuardar);
            grpDatos.Controls.Add(cmdEliminar);
            grpDatos.Controls.Add(cmdModificar);
            grpDatos.Controls.Add(cbxCategorias);
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
            grpDatos.Location = new Point(12, 13);
            grpDatos.Margin = new Padding(3, 4, 3, 4);
            grpDatos.Name = "grpDatos";
            grpDatos.Padding = new Padding(3, 4, 3, 4);
            grpDatos.Size = new Size(789, 409);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Informacion del producto";
            // 
            // cmdGuardar
            // 
            cmdGuardar.BackColor = Color.Gainsboro;
            cmdGuardar.FlatStyle = FlatStyle.Popup;
            cmdGuardar.Location = new Point(44, 329);
            cmdGuardar.Name = "cmdGuardar";
            cmdGuardar.Size = new Size(153, 53);
            cmdGuardar.TabIndex = 17;
            cmdGuardar.Text = "GUARDAR";
            cmdGuardar.UseVisualStyleBackColor = false;
            // 
            // cmdEliminar
            // 
            cmdEliminar.BackColor = Color.Gainsboro;
            cmdEliminar.FlatStyle = FlatStyle.Popup;
            cmdEliminar.Location = new Point(585, 329);
            cmdEliminar.Name = "cmdEliminar";
            cmdEliminar.Size = new Size(153, 53);
            cmdEliminar.TabIndex = 16;
            cmdEliminar.Text = "ELIMINAR";
            cmdEliminar.UseVisualStyleBackColor = false;
            // 
            // cmdModificar
            // 
            cmdModificar.BackColor = Color.Gainsboro;
            cmdModificar.FlatStyle = FlatStyle.Popup;
            cmdModificar.Location = new Point(325, 329);
            cmdModificar.Name = "cmdModificar";
            cmdModificar.Size = new Size(153, 53);
            cmdModificar.TabIndex = 15;
            cmdModificar.Text = "MODIFICAR";
            cmdModificar.UseVisualStyleBackColor = false;
            // 
            // cbxCategorias
            // 
            cbxCategorias.FormattingEnabled = true;
            cbxCategorias.Location = new Point(144, 126);
            cbxCategorias.Name = "cbxCategorias";
            cbxCategorias.Size = new Size(224, 26);
            cbxCategorias.TabIndex = 13;
            // 
            // txtPCompra
            // 
            txtPCompra.Location = new Point(205, 85);
            txtPCompra.Multiline = true;
            txtPCompra.Name = "txtPCompra";
            txtPCompra.Size = new Size(163, 23);
            txtPCompra.TabIndex = 12;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(144, 46);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(224, 23);
            txtNombre.TabIndex = 11;
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
            // 
            // txtPVenta
            // 
            txtPVenta.Location = new Point(561, 85);
            txtPVenta.Multiline = true;
            txtPVenta.Name = "txtPVenta";
            txtPVenta.Size = new Size(177, 23);
            txtPVenta.TabIndex = 8;
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
            // cmdEmail
            // 
            cmdEmail.BackColor = Color.Gainsboro;
            cmdEmail.FlatStyle = FlatStyle.Popup;
            cmdEmail.Location = new Point(648, 453);
            cmdEmail.Name = "cmdEmail";
            cmdEmail.Size = new Size(153, 53);
            cmdEmail.TabIndex = 14;
            cmdEmail.Text = "MANDAR MENSAJE";
            cmdEmail.UseVisualStyleBackColor = false;
            // 
            // frmDetalleProducto
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(827, 520);
            Controls.Add(grpDatos);
            Controls.Add(cmdEmail);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDetalleProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle del producto";
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private Button cmdEliminar;
        private Button cmdModificar;
        private Button cmdEmail;
        private ComboBox cbxCategorias;
        private TextBox txtPCompra;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtStock;
        private TextBox txtPVenta;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button cmdGuardar;
    }
}