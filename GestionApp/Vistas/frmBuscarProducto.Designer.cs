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
            grpDatos = new GroupBox();
            cmbCategoria = new ComboBox();
            label7 = new Label();
            cmdGuardar = new Button();
            cmdEliminar = new Button();
            cmdModificar = new Button();
            txtDescripcion = new TextBox();
            txtStock = new TextBox();
            txtPCompra = new TextBox();
            txtNombre = new TextBox();
            txtPVenta = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            cmdBuscar = new Button();
            txtProducto = new TextBox();
            label3 = new Label();
            cmdCancelar = new Button();
            grpBuscar.SuspendLayout();
            grpDatos.SuspendLayout();
            SuspendLayout();
            // 
            // grpBuscar
            // 
            grpBuscar.Controls.Add(grpDatos);
            grpBuscar.Controls.Add(cmdBuscar);
            grpBuscar.Controls.Add(txtProducto);
            grpBuscar.Controls.Add(label3);
            grpBuscar.Location = new Point(12, 12);
            grpBuscar.Name = "grpBuscar";
            grpBuscar.Size = new Size(892, 511);
            grpBuscar.TabIndex = 0;
            grpBuscar.TabStop = false;
            grpBuscar.Text = "Buscar";
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(cmdCancelar);
            grpDatos.Controls.Add(cmbCategoria);
            grpDatos.Controls.Add(label7);
            grpDatos.Controls.Add(cmdGuardar);
            grpDatos.Controls.Add(cmdEliminar);
            grpDatos.Controls.Add(cmdModificar);
            grpDatos.Controls.Add(txtDescripcion);
            grpDatos.Controls.Add(txtStock);
            grpDatos.Controls.Add(txtPCompra);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(txtPVenta);
            grpDatos.Controls.Add(label6);
            grpDatos.Controls.Add(label5);
            grpDatos.Controls.Add(label4);
            grpDatos.Controls.Add(label1);
            grpDatos.Controls.Add(label2);
            grpDatos.Location = new Point(19, 137);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(855, 359);
            grpDatos.TabIndex = 53;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos";
            // 
            // cmbCategoria
            // 
            cmbCategoria.Enabled = false;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(147, 122);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(243, 26);
            cmbCategoria.TabIndex = 54;
            // 
            // label7
            // 
            label7.Location = new Point(47, 122);
            label7.Name = "label7";
            label7.Size = new Size(94, 24);
            label7.TabIndex = 40;
            label7.Text = "Categoría:";
            // 
            // cmdGuardar
            // 
            cmdGuardar.BackColor = Color.Gainsboro;
            cmdGuardar.Enabled = false;
            cmdGuardar.FlatStyle = FlatStyle.Popup;
            cmdGuardar.Location = new Point(47, 297);
            cmdGuardar.Name = "cmdGuardar";
            cmdGuardar.Size = new Size(153, 42);
            cmdGuardar.TabIndex = 39;
            cmdGuardar.Text = "GUARDAR";
            cmdGuardar.UseVisualStyleBackColor = false;
            cmdGuardar.Click += cmdGuardar_Click;
            // 
            // cmdEliminar
            // 
            cmdEliminar.BackColor = Color.Gainsboro;
            cmdEliminar.Enabled = false;
            cmdEliminar.FlatStyle = FlatStyle.Popup;
            cmdEliminar.Location = new Point(648, 297);
            cmdEliminar.Name = "cmdEliminar";
            cmdEliminar.Size = new Size(153, 42);
            cmdEliminar.TabIndex = 38;
            cmdEliminar.Text = "ELIMINAR";
            cmdEliminar.UseVisualStyleBackColor = false;
            cmdEliminar.Click += cmdEliminar_Click;
            // 
            // cmdModificar
            // 
            cmdModificar.BackColor = Color.Gainsboro;
            cmdModificar.Enabled = false;
            cmdModificar.FlatStyle = FlatStyle.Popup;
            cmdModificar.Location = new Point(357, 297);
            cmdModificar.Name = "cmdModificar";
            cmdModificar.Size = new Size(153, 42);
            cmdModificar.TabIndex = 37;
            cmdModificar.Text = "MODIFICAR";
            cmdModificar.UseVisualStyleBackColor = false;
            cmdModificar.Click += cmdModificar_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Enabled = false;
            txtDescripcion.Location = new Point(160, 169);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(641, 65);
            txtDescripcion.TabIndex = 36;
            // 
            // txtStock
            // 
            txtStock.Enabled = false;
            txtStock.Location = new Point(511, 78);
            txtStock.Multiline = true;
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(290, 23);
            txtStock.TabIndex = 35;
            // 
            // txtPCompra
            // 
            txtPCompra.Enabled = false;
            txtPCompra.Location = new Point(185, 78);
            txtPCompra.Multiline = true;
            txtPCompra.Name = "txtPCompra";
            txtPCompra.Size = new Size(205, 23);
            txtPCompra.TabIndex = 34;
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(134, 37);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(256, 23);
            txtNombre.TabIndex = 33;
            // 
            // txtPVenta
            // 
            txtPVenta.Enabled = false;
            txtPVenta.Location = new Point(559, 37);
            txtPVenta.Multiline = true;
            txtPVenta.Name = "txtPVenta";
            txtPVenta.Size = new Size(242, 23);
            txtPVenta.TabIndex = 32;
            // 
            // label6
            // 
            label6.Location = new Point(47, 81);
            label6.Name = "label6";
            label6.Size = new Size(141, 28);
            label6.TabIndex = 31;
            label6.Text = "Precio Compra:";
            // 
            // label5
            // 
            label5.Location = new Point(426, 81);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 30;
            label5.Text = "Stock:";
            // 
            // label4
            // 
            label4.Location = new Point(47, 169);
            label4.Name = "label4";
            label4.Size = new Size(94, 24);
            label4.TabIndex = 29;
            label4.Text = "Descripción:";
            // 
            // label1
            // 
            label1.Location = new Point(426, 40);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 28;
            label1.Text = "Precio Venta: ";
            // 
            // label2
            // 
            label2.Location = new Point(47, 40);
            label2.Name = "label2";
            label2.Size = new Size(94, 28);
            label2.TabIndex = 27;
            label2.Text = "Nombre:";
            // 
            // cmdBuscar
            // 
            cmdBuscar.BackColor = Color.Gainsboro;
            cmdBuscar.FlatStyle = FlatStyle.Popup;
            cmdBuscar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdBuscar.Location = new Point(504, 93);
            cmdBuscar.Name = "cmdBuscar";
            cmdBuscar.Size = new Size(134, 26);
            cmdBuscar.TabIndex = 52;
            cmdBuscar.Text = "BUSCAR";
            cmdBuscar.UseVisualStyleBackColor = false;
            cmdBuscar.Click += cmdBuscar_Click;
            // 
            // txtProducto
            // 
            txtProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProducto.Location = new Point(331, 49);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(307, 26);
            txtProducto.TabIndex = 50;
            // 
            // label3
            // 
            label3.Location = new Point(223, 52);
            label3.Name = "label3";
            label3.Size = new Size(102, 22);
            label3.TabIndex = 49;
            label3.Text = "Producto:";
            // 
            // cmdCancelar
            // 
            cmdCancelar.BackColor = Color.Gainsboro;
            cmdCancelar.Enabled = false;
            cmdCancelar.FlatStyle = FlatStyle.Popup;
            cmdCancelar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdCancelar.Location = new Point(667, 240);
            cmdCancelar.Name = "cmdCancelar";
            cmdCancelar.Size = new Size(134, 26);
            cmdCancelar.TabIndex = 54;
            cmdCancelar.Text = "CANCELAR";
            cmdCancelar.UseVisualStyleBackColor = false;
            cmdCancelar.Visible = false;
            cmdCancelar.Click += cmdCancelar_Click;
            // 
            // frmBuscarProducto
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(917, 529);
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
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBuscar;
        private TextBox txtProducto;
        private Label label3;
        private Button cmdBuscar;
        private GroupBox grpDatos;
        private TextBox txtDescripcion;
        private TextBox txtStock;
        private TextBox txtPCompra;
        private TextBox txtNombre;
        private TextBox txtPVenta;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
        private Label label2;
        private Button cmdGuardar;
        private Button cmdEliminar;
        private Button cmdModificar;
        private Label label7;
        private ComboBox cmbCategoria;
        private Button cmdCancelar;
    }
}