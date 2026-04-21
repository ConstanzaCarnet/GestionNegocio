namespace GestionApp
{
    partial class frmNuevaVenta
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
            label1 = new Label();
            label7 = new Label();
            cmdContinuar = new Button();
            cbmClientes = new ComboBox();
            cmdSeleccionar = new Button();
            grpDatos = new GroupBox();
            cmdCancelar = new Button();
            grpCargaProductos = new GroupBox();
            cmbCantidad = new ComboBox();
            cmdCambiarCliente = new Button();
            lblCliente = new Label();
            lblEtCliente = new Label();
            label4 = new Label();
            cmdAgregar = new Button();
            dgvGrilla = new DataGridView();
            cmbProductos = new ComboBox();
            lblTotal = new Label();
            label3 = new Label();
            Nombre = new DataGridViewTextBoxColumn();
            PrecioUnitario = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Subtotal = new DataGridViewTextBoxColumn();
            cmdAumentar = new DataGridViewButtonColumn();
            cmdDisminuir = new DataGridViewButtonColumn();
            cmdQuitar = new DataGridViewButtonColumn();
            grpDatos.SuspendLayout();
            grpCargaProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(122, 42);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 14;
            label1.Text = "Cliente:";
            // 
            // label7
            // 
            label7.Location = new Point(537, 406);
            label7.Name = "label7";
            label7.Size = new Size(108, 20);
            label7.TabIndex = 16;
            label7.Text = "Monto total:";
            // 
            // cmdContinuar
            // 
            cmdContinuar.BackColor = Color.Gainsboro;
            cmdContinuar.FlatStyle = FlatStyle.Popup;
            cmdContinuar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdContinuar.Location = new Point(660, 643);
            cmdContinuar.Name = "cmdContinuar";
            cmdContinuar.Size = new Size(210, 42);
            cmdContinuar.TabIndex = 27;
            cmdContinuar.Text = "CONTINUAR";
            cmdContinuar.UseVisualStyleBackColor = false;
            cmdContinuar.Click += cmdContinuar_Click;
            // 
            // cbmClientes
            // 
            cbmClientes.FormattingEnabled = true;
            cbmClientes.Location = new Point(238, 38);
            cbmClientes.Name = "cbmClientes";
            cbmClientes.Size = new Size(253, 26);
            cbmClientes.TabIndex = 28;
            // 
            // cmdSeleccionar
            // 
            cmdSeleccionar.BackColor = Color.Gainsboro;
            cmdSeleccionar.FlatStyle = FlatStyle.Popup;
            cmdSeleccionar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdSeleccionar.Location = new Point(553, 38);
            cmdSeleccionar.Name = "cmdSeleccionar";
            cmdSeleccionar.Size = new Size(165, 26);
            cmdSeleccionar.TabIndex = 34;
            cmdSeleccionar.Text = "SELECCIONAR";
            cmdSeleccionar.UseVisualStyleBackColor = false;
            cmdSeleccionar.Click += cmdSeleccionar_Click;
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(cmdCancelar);
            grpDatos.Controls.Add(grpCargaProductos);
            grpDatos.Controls.Add(cmdSeleccionar);
            grpDatos.Controls.Add(cbmClientes);
            grpDatos.Controls.Add(cmdContinuar);
            grpDatos.Controls.Add(label1);
            grpDatos.Location = new Point(13, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(885, 705);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Cargar datos";
            // 
            // cmdCancelar
            // 
            cmdCancelar.BackColor = Color.Gainsboro;
            cmdCancelar.FlatStyle = FlatStyle.Popup;
            cmdCancelar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdCancelar.Location = new Point(16, 643);
            cmdCancelar.Name = "cmdCancelar";
            cmdCancelar.Size = new Size(210, 42);
            cmdCancelar.TabIndex = 43;
            cmdCancelar.Text = "CANCELAR";
            cmdCancelar.UseVisualStyleBackColor = false;
            cmdCancelar.Click += cmdCancelar_Click;
            // 
            // grpCargaProductos
            // 
            grpCargaProductos.Controls.Add(cmbCantidad);
            grpCargaProductos.Controls.Add(cmdCambiarCliente);
            grpCargaProductos.Controls.Add(lblCliente);
            grpCargaProductos.Controls.Add(lblEtCliente);
            grpCargaProductos.Controls.Add(label4);
            grpCargaProductos.Controls.Add(cmdAgregar);
            grpCargaProductos.Controls.Add(dgvGrilla);
            grpCargaProductos.Controls.Add(cmbProductos);
            grpCargaProductos.Controls.Add(lblTotal);
            grpCargaProductos.Controls.Add(label3);
            grpCargaProductos.Controls.Add(label7);
            grpCargaProductos.Location = new Point(16, 90);
            grpCargaProductos.Name = "grpCargaProductos";
            grpCargaProductos.Size = new Size(854, 534);
            grpCargaProductos.TabIndex = 35;
            grpCargaProductos.TabStop = false;
            grpCargaProductos.Text = "Datos de la venta";
            // 
            // cmbCantidad
            // 
            cmbCantidad.FormattingEnabled = true;
            cmbCantidad.Location = new Point(676, 27);
            cmbCantidad.Name = "cmbCantidad";
            cmbCantidad.Size = new Size(160, 26);
            cmbCantidad.TabIndex = 51;
            // 
            // cmdCambiarCliente
            // 
            cmdCambiarCliente.BackColor = Color.Gainsboro;
            cmdCambiarCliente.FlatStyle = FlatStyle.Popup;
            cmdCambiarCliente.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdCambiarCliente.Location = new Point(87, 455);
            cmdCambiarCliente.Name = "cmdCambiarCliente";
            cmdCambiarCliente.Size = new Size(235, 26);
            cmdCambiarCliente.TabIndex = 44;
            cmdCambiarCliente.Text = "CAMBIAR CLIENTE";
            cmdCambiarCliente.UseVisualStyleBackColor = false;
            cmdCambiarCliente.Click += cmdCambiarCliente_Click;
            // 
            // lblCliente
            // 
            lblCliente.BorderStyle = BorderStyle.Fixed3D;
            lblCliente.FlatStyle = FlatStyle.Popup;
            lblCliente.Location = new Point(87, 405);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(235, 28);
            lblCliente.TabIndex = 50;
            // 
            // lblEtCliente
            // 
            lblEtCliente.Location = new Point(25, 413);
            lblEtCliente.Name = "lblEtCliente";
            lblEtCliente.Size = new Size(108, 20);
            lblEtCliente.TabIndex = 49;
            lblEtCliente.Text = "Cliente:";
            // 
            // label4
            // 
            label4.Location = new Point(576, 30);
            label4.Name = "label4";
            label4.Size = new Size(94, 22);
            label4.TabIndex = 47;
            label4.Text = "Cantidad:";
            // 
            // cmdAgregar
            // 
            cmdAgregar.BackColor = Color.Gainsboro;
            cmdAgregar.Enabled = false;
            cmdAgregar.FlatStyle = FlatStyle.Popup;
            cmdAgregar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdAgregar.Location = new Point(647, 87);
            cmdAgregar.Name = "cmdAgregar";
            cmdAgregar.Size = new Size(165, 26);
            cmdAgregar.TabIndex = 46;
            cmdAgregar.Text = "AGREGAR";
            cmdAgregar.UseVisualStyleBackColor = false;
            cmdAgregar.Click += cmdAgregar_Click;
            // 
            // dgvGrilla
            // 
            dgvGrilla.AllowUserToAddRows = false;
            dgvGrilla.AllowUserToDeleteRows = false;
            dgvGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrilla.Columns.AddRange(new DataGridViewColumn[] { Nombre, PrecioUnitario, Cantidad, Subtotal, cmdAumentar, cmdDisminuir, cmdQuitar });
            dgvGrilla.Location = new Point(16, 130);
            dgvGrilla.Name = "dgvGrilla";
            dgvGrilla.ReadOnly = true;
            dgvGrilla.RowHeadersVisible = false;
            dgvGrilla.ScrollBars = ScrollBars.Vertical;
            dgvGrilla.Size = new Size(820, 246);
            dgvGrilla.TabIndex = 0;
            dgvGrilla.CellContentClick += dgvGrilla_CellContentClick;
            // 
            // cmbProductos
            // 
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(130, 27);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(368, 26);
            cmbProductos.TabIndex = 45;
            cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;
            // 
            // lblTotal
            // 
            lblTotal.BorderStyle = BorderStyle.Fixed3D;
            lblTotal.FlatStyle = FlatStyle.Popup;
            lblTotal.Location = new Point(651, 398);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(185, 28);
            lblTotal.TabIndex = 30;
            // 
            // label3
            // 
            label3.Location = new Point(30, 30);
            label3.Name = "label3";
            label3.Size = new Size(94, 22);
            label3.TabIndex = 44;
            label3.Text = "Producto:";
            // 
            // Nombre
            // 
            Nombre.DataPropertyName = "Nombre";
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 250;
            // 
            // PrecioUnitario
            // 
            PrecioUnitario.DataPropertyName = "PrecioUnitario";
            PrecioUnitario.HeaderText = "Precio unitario";
            PrecioUnitario.Name = "PrecioUnitario";
            PrecioUnitario.ReadOnly = true;
            PrecioUnitario.Width = 150;
            // 
            // Cantidad
            // 
            Cantidad.DataPropertyName = "Cantidad";
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            Cantidad.Width = 150;
            // 
            // Subtotal
            // 
            Subtotal.DataPropertyName = "Subtotal";
            Subtotal.HeaderText = "Subtotal";
            Subtotal.Name = "Subtotal";
            Subtotal.ReadOnly = true;
            Subtotal.Width = 150;
            // 
            // cmdAumentar
            // 
            cmdAumentar.DataPropertyName = "cmdAumentar";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            cmdAumentar.DefaultCellStyle = dataGridViewCellStyle1;
            cmdAumentar.HeaderText = "";
            cmdAumentar.Name = "cmdAumentar";
            cmdAumentar.ReadOnly = true;
            cmdAumentar.Text = "+";
            cmdAumentar.UseColumnTextForButtonValue = true;
            cmdAumentar.Width = 40;
            // 
            // cmdDisminuir
            // 
            cmdDisminuir.DataPropertyName = "cmdDisminuir";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(192, 255, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            cmdDisminuir.DefaultCellStyle = dataGridViewCellStyle2;
            cmdDisminuir.HeaderText = "";
            cmdDisminuir.Name = "cmdDisminuir";
            cmdDisminuir.ReadOnly = true;
            cmdDisminuir.Text = "-";
            cmdDisminuir.UseColumnTextForButtonValue = true;
            cmdDisminuir.Width = 40;
            // 
            // cmdQuitar
            // 
            cmdQuitar.DataPropertyName = "cmdQuitar";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(192, 0, 0);
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(192, 0, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            cmdQuitar.DefaultCellStyle = dataGridViewCellStyle3;
            cmdQuitar.HeaderText = "";
            cmdQuitar.Name = "cmdQuitar";
            cmdQuitar.ReadOnly = true;
            cmdQuitar.Text = "X";
            cmdQuitar.UseColumnTextForButtonValue = true;
            cmdQuitar.Width = 40;
            // 
            // frmNuevaVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(912, 729);
            Controls.Add(grpDatos);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNuevaVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva venta";
            Load += frmNuevaVenta_Load;
            grpDatos.ResumeLayout(false);
            grpCargaProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label7;
        private Button cmdContinuar;
        private ComboBox cbmClientes;
        private Button cmdSeleccionar;
        private GroupBox grpDatos;
        private Label lblTotal;
        private Button cmdCancelar;
        private GroupBox grpCargaProductos;
        private Button cmdAgregar;
        private DataGridView dgvGrilla;
        private ComboBox cmbProductos;
        private Label label3;
        private Label label4;
        private Button cmdCambiarCliente;
        private Label lblCliente;
        private Label lblEtCliente;
        private ComboBox cmbCantidad;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn PrecioUnitario;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Subtotal;
        private DataGridViewButtonColumn cmdAumentar;
        private DataGridViewButtonColumn cmdDisminuir;
        private DataGridViewButtonColumn cmdQuitar;
    }
}