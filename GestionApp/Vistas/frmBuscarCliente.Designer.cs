namespace GestionApp
{
    partial class frmBuscarCliente
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
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            txtPCompra = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            cmbCliente = new ComboBox();
            cmdBuscar = new Button();
            cmdGuardar = new Button();
            cmdEliminar = new Button();
            cmdModificar = new Button();
            dataGridView1 = new DataGridView();
            label7 = new Label();
            cmdCargarPago = new Button();
            lblSaldo = new Label();
            label8 = new Label();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(lblSaldo);
            grpDatos.Controls.Add(label8);
            grpDatos.Controls.Add(cmdCargarPago);
            grpDatos.Controls.Add(label7);
            grpDatos.Controls.Add(dataGridView1);
            grpDatos.Controls.Add(cmdGuardar);
            grpDatos.Controls.Add(cmdEliminar);
            grpDatos.Controls.Add(cmdModificar);
            grpDatos.Controls.Add(cmdBuscar);
            grpDatos.Controls.Add(cmbCliente);
            grpDatos.Controls.Add(label2);
            grpDatos.Controls.Add(textBox2);
            grpDatos.Controls.Add(textBox1);
            grpDatos.Controls.Add(txtPCompra);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(txtApellido);
            grpDatos.Controls.Add(label6);
            grpDatos.Controls.Add(label5);
            grpDatos.Controls.Add(label4);
            grpDatos.Controls.Add(label3);
            grpDatos.Controls.Add(label1);
            grpDatos.Location = new Point(12, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(717, 791);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Cargar datos";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(117, 297);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(568, 23);
            textBox2.TabIndex = 26;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(438, 250);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(247, 23);
            textBox1.TabIndex = 25;
            // 
            // txtPCompra
            // 
            txtPCompra.Location = new Point(105, 250);
            txtPCompra.Multiline = true;
            txtPCompra.Name = "txtPCompra";
            txtPCompra.Size = new Size(196, 23);
            txtPCompra.TabIndex = 23;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(128, 210);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(173, 23);
            txtNombre.TabIndex = 22;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(431, 210);
            txtApellido.Multiline = true;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(254, 23);
            txtApellido.TabIndex = 20;
            // 
            // label6
            // 
            label6.Location = new Point(37, 253);
            label6.Name = "label6";
            label6.Size = new Size(141, 28);
            label6.TabIndex = 19;
            label6.Text = "Email:";
            // 
            // label5
            // 
            label5.Location = new Point(348, 253);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 18;
            label5.Text = "Teléfono:";
            // 
            // label4
            // 
            label4.Location = new Point(37, 300);
            label4.Name = "label4";
            label4.Size = new Size(94, 24);
            label4.TabIndex = 17;
            label4.Text = "Dirección:";
            // 
            // label3
            // 
            label3.Location = new Point(348, 213);
            label3.Name = "label3";
            label3.Size = new Size(64, 28);
            label3.TabIndex = 16;
            label3.Text = "Apellido:";
            // 
            // label1
            // 
            label1.Location = new Point(37, 213);
            label1.Name = "label1";
            label1.Size = new Size(94, 28);
            label1.TabIndex = 14;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.Location = new Point(149, 45);
            label2.Name = "label2";
            label2.Size = new Size(94, 28);
            label2.TabIndex = 28;
            label2.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(272, 42);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(317, 26);
            cmbCliente.TabIndex = 29;
            // 
            // cmdBuscar
            // 
            cmdBuscar.BackColor = Color.Gainsboro;
            cmdBuscar.FlatStyle = FlatStyle.Popup;
            cmdBuscar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdBuscar.Location = new Point(379, 95);
            cmdBuscar.Name = "cmdBuscar";
            cmdBuscar.Size = new Size(210, 42);
            cmdBuscar.TabIndex = 30;
            cmdBuscar.Text = "BUSCAR";
            cmdBuscar.UseVisualStyleBackColor = false;
            // 
            // cmdGuardar
            // 
            cmdGuardar.BackColor = Color.Gainsboro;
            cmdGuardar.FlatStyle = FlatStyle.Popup;
            cmdGuardar.Location = new Point(25, 715);
            cmdGuardar.Name = "cmdGuardar";
            cmdGuardar.Size = new Size(153, 53);
            cmdGuardar.TabIndex = 33;
            cmdGuardar.Text = "GUARDAR";
            cmdGuardar.UseVisualStyleBackColor = false;
            // 
            // cmdEliminar
            // 
            cmdEliminar.BackColor = Color.Gainsboro;
            cmdEliminar.FlatStyle = FlatStyle.Popup;
            cmdEliminar.Location = new Point(543, 715);
            cmdEliminar.Name = "cmdEliminar";
            cmdEliminar.Size = new Size(153, 53);
            cmdEliminar.TabIndex = 32;
            cmdEliminar.Text = "ELIMINAR";
            cmdEliminar.UseVisualStyleBackColor = false;
            // 
            // cmdModificar
            // 
            cmdModificar.BackColor = Color.Gainsboro;
            cmdModificar.FlatStyle = FlatStyle.Popup;
            cmdModificar.Location = new Point(288, 715);
            cmdModificar.Name = "cmdModificar";
            cmdModificar.Size = new Size(153, 53);
            cmdModificar.TabIndex = 31;
            cmdModificar.Text = "MODIFICAR";
            cmdModificar.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 378);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.Size = new Size(671, 241);
            dataGridView1.TabIndex = 34;
            // 
            // label7
            // 
            label7.Location = new Point(37, 351);
            label7.Name = "label7";
            label7.Size = new Size(178, 24);
            label7.TabIndex = 35;
            label7.Text = "Movimientos del cliente:";
            // 
            // cmdCargarPago
            // 
            cmdCargarPago.BackColor = Color.Gainsboro;
            cmdCargarPago.FlatStyle = FlatStyle.Popup;
            cmdCargarPago.Location = new Point(543, 640);
            cmdCargarPago.Name = "cmdCargarPago";
            cmdCargarPago.Size = new Size(153, 27);
            cmdCargarPago.TabIndex = 36;
            cmdCargarPago.Text = "CARGAR PAGO";
            cmdCargarPago.UseVisualStyleBackColor = false;
            // 
            // lblSaldo
            // 
            lblSaldo.BorderStyle = BorderStyle.Fixed3D;
            lblSaldo.FlatStyle = FlatStyle.Popup;
            lblSaldo.Location = new Point(171, 632);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(166, 28);
            lblSaldo.TabIndex = 38;
            // 
            // label8
            // 
            label8.Location = new Point(37, 640);
            label8.Name = "label8";
            label8.Size = new Size(108, 20);
            label8.TabIndex = 37;
            label8.Text = "Saldo total:";
            // 
            // frmBuscarCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(741, 815);
            Controls.Add(grpDatos);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBuscarCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar cliente";
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox txtPCompra;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Button cmdBuscar;
        private ComboBox cmbCliente;
        private Label label7;
        private DataGridView dataGridView1;
        private Button cmdGuardar;
        private Button cmdEliminar;
        private Button cmdModificar;
        private Button cmdCargarPago;
        private Label lblSaldo;
        private Label label8;
    }
}