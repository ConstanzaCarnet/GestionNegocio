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
            label1 = new Label();
            label7 = new Label();
            cmdContinuar = new Button();
            cbmClientes = new ComboBox();
            cmdSeleccionar = new Button();
            grpDatos = new GroupBox();
            cmdCancelar = new Button();
            grpCargaProductos = new GroupBox();
            txtCantidad = new TextBox();
            label4 = new Label();
            cmdAgregar = new Button();
            dgvGrilla = new DataGridView();
            cmbProductos = new ComboBox();
            lblTotal = new Label();
            label3 = new Label();
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
            label7.Location = new Point(537, 424);
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
            cmdContinuar.Location = new Point(660, 574);
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
            grpDatos.Size = new Size(885, 627);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Cargar datos";
            // 
            // cmdCancelar
            // 
            cmdCancelar.BackColor = Color.Gainsboro;
            cmdCancelar.FlatStyle = FlatStyle.Popup;
            cmdCancelar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdCancelar.Location = new Point(16, 574);
            cmdCancelar.Name = "cmdCancelar";
            cmdCancelar.Size = new Size(210, 42);
            cmdCancelar.TabIndex = 43;
            cmdCancelar.Text = "CANCELAR";
            cmdCancelar.UseVisualStyleBackColor = false;
            // 
            // grpCargaProductos
            // 
            grpCargaProductos.Controls.Add(txtCantidad);
            grpCargaProductos.Controls.Add(label4);
            grpCargaProductos.Controls.Add(cmdAgregar);
            grpCargaProductos.Controls.Add(dgvGrilla);
            grpCargaProductos.Controls.Add(cmbProductos);
            grpCargaProductos.Controls.Add(lblTotal);
            grpCargaProductos.Controls.Add(label3);
            grpCargaProductos.Controls.Add(label7);
            grpCargaProductos.Location = new Point(16, 90);
            grpCargaProductos.Name = "grpCargaProductos";
            grpCargaProductos.Size = new Size(854, 467);
            grpCargaProductos.TabIndex = 35;
            grpCargaProductos.TabStop = false;
            grpCargaProductos.Text = "Cargar productos";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(694, 30);
            txtCantidad.Multiline = true;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(118, 23);
            txtCantidad.TabIndex = 48;
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
            cmdAgregar.FlatStyle = FlatStyle.Popup;
            cmdAgregar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdAgregar.Location = new Point(647, 87);
            cmdAgregar.Name = "cmdAgregar";
            cmdAgregar.Size = new Size(165, 26);
            cmdAgregar.TabIndex = 46;
            cmdAgregar.Text = "AGREGAR";
            cmdAgregar.UseVisualStyleBackColor = false;
            // 
            // dgvGrilla
            // 
            dgvGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrilla.Location = new Point(16, 130);
            dgvGrilla.Name = "dgvGrilla";
            dgvGrilla.ScrollBars = ScrollBars.Vertical;
            dgvGrilla.Size = new Size(820, 246);
            dgvGrilla.TabIndex = 0;
            // 
            // cmbProductos
            // 
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(130, 27);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(368, 26);
            cmbProductos.TabIndex = 45;
            // 
            // lblTotal
            // 
            lblTotal.BorderStyle = BorderStyle.Fixed3D;
            lblTotal.FlatStyle = FlatStyle.Popup;
            lblTotal.Location = new Point(670, 416);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(166, 28);
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
            // frmNuevaVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(912, 651);
            Controls.Add(grpDatos);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNuevaVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva venta";
            grpDatos.ResumeLayout(false);
            grpCargaProductos.ResumeLayout(false);
            grpCargaProductos.PerformLayout();
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
        private TextBox txtCantidad;
    }
}