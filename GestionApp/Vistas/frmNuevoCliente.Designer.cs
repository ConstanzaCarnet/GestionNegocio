namespace GestionApp
{
    partial class frmNuevoCliente
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
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            cmdTodos = new Button();
            cmdDeudores = new Button();
            dgvGrilla = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            Direccion = new DataGridViewTextBoxColumn();
            Saldo = new DataGridViewTextBoxColumn();
            grpDatos.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(cmdAgregar);
            grpDatos.Controls.Add(txtDireccion);
            grpDatos.Controls.Add(txtTelefono);
            grpDatos.Controls.Add(txtEmail);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(txtApellido);
            grpDatos.Controls.Add(label6);
            grpDatos.Controls.Add(label5);
            grpDatos.Controls.Add(label4);
            grpDatos.Controls.Add(label3);
            grpDatos.Controls.Add(label1);
            grpDatos.Location = new Point(12, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(1421, 227);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Cargar datos";
            // 
            // cmdAgregar
            // 
            cmdAgregar.BackColor = Color.Gainsboro;
            cmdAgregar.Enabled = false;
            cmdAgregar.FlatStyle = FlatStyle.Popup;
            cmdAgregar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdAgregar.Location = new Point(970, 167);
            cmdAgregar.Name = "cmdAgregar";
            cmdAgregar.Size = new Size(210, 42);
            cmdAgregar.TabIndex = 27;
            cmdAgregar.Text = "AGREGAR";
            cmdAgregar.UseVisualStyleBackColor = false;
            cmdAgregar.Click += cmdAgregar_Click;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(323, 128);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(857, 23);
            txtDireccion.TabIndex = 26;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(822, 81);
            txtTelefono.Multiline = true;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(358, 23);
            txtTelefono.TabIndex = 25;
            txtTelefono.TextChanged += textTelefono_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(302, 81);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(383, 23);
            txtEmail.TabIndex = 23;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(323, 41);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(362, 23);
            txtNombre.TabIndex = 22;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(818, 41);
            txtApellido.Multiline = true;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(362, 23);
            txtApellido.TabIndex = 20;
            txtApellido.TextChanged += txtApellido_TextChanged;
            // 
            // label6
            // 
            label6.Location = new Point(238, 84);
            label6.Name = "label6";
            label6.Size = new Size(141, 28);
            label6.TabIndex = 19;
            label6.Text = "Email:";
            // 
            // label5
            // 
            label5.Location = new Point(732, 84);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 18;
            label5.Text = "Teléfono:";
            // 
            // label4
            // 
            label4.Location = new Point(238, 131);
            label4.Name = "label4";
            label4.Size = new Size(94, 24);
            label4.TabIndex = 17;
            label4.Text = "Dirección:";
            // 
            // label3
            // 
            label3.Location = new Point(732, 44);
            label3.Name = "label3";
            label3.Size = new Size(64, 28);
            label3.TabIndex = 16;
            label3.Text = "Apellido:";
            // 
            // label1
            // 
            label1.Location = new Point(238, 44);
            label1.Name = "label1";
            label1.Size = new Size(94, 28);
            label1.TabIndex = 14;
            label1.Text = "Nombre:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdTodos);
            groupBox1.Controls.Add(cmdDeudores);
            groupBox1.Controls.Add(dgvGrilla);
            groupBox1.Location = new Point(12, 245);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1421, 525);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Todos los clientes";
            // 
            // cmdTodos
            // 
            cmdTodos.BackColor = Color.Gainsboro;
            cmdTodos.FlatStyle = FlatStyle.Popup;
            cmdTodos.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdTodos.Location = new Point(24, 481);
            cmdTodos.Name = "cmdTodos";
            cmdTodos.Size = new Size(194, 26);
            cmdTodos.TabIndex = 36;
            cmdTodos.Text = "VER TODOS";
            cmdTodos.UseVisualStyleBackColor = false;
            cmdTodos.Click += cmdTodos_Click;
            // 
            // cmdDeudores
            // 
            cmdDeudores.BackColor = Color.Gainsboro;
            cmdDeudores.FlatStyle = FlatStyle.Popup;
            cmdDeudores.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdDeudores.Location = new Point(1210, 481);
            cmdDeudores.Name = "cmdDeudores";
            cmdDeudores.Size = new Size(194, 26);
            cmdDeudores.TabIndex = 35;
            cmdDeudores.Text = "VER DEUDORES";
            cmdDeudores.UseVisualStyleBackColor = false;
            cmdDeudores.Click += cmdDeudores_Click;
            // 
            // dgvGrilla
            // 
            dgvGrilla.AllowUserToAddRows = false;
            dgvGrilla.AllowUserToDeleteRows = false;
            dgvGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrilla.Columns.AddRange(new DataGridViewColumn[] { Nombre, Apellido, Email, Telefono, Direccion, Saldo });
            dgvGrilla.Location = new Point(24, 36);
            dgvGrilla.Name = "dgvGrilla";
            dgvGrilla.ReadOnly = true;
            dgvGrilla.RowHeadersVisible = false;
            dgvGrilla.ScrollBars = ScrollBars.Vertical;
            dgvGrilla.Size = new Size(1380, 428);
            dgvGrilla.TabIndex = 1;
            // 
            // Nombre
            // 
            Nombre.DataPropertyName = "Nombre";
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 250;
            // 
            // Apellido
            // 
            Apellido.DataPropertyName = "Apellido";
            Apellido.HeaderText = "Apellido";
            Apellido.Name = "Apellido";
            Apellido.ReadOnly = true;
            Apellido.Width = 250;
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.Name = "Email";
            Email.ReadOnly = true;
            Email.Width = 300;
            // 
            // Telefono
            // 
            Telefono.DataPropertyName = "Telefono";
            Telefono.HeaderText = "Teléfono";
            Telefono.Name = "Telefono";
            Telefono.ReadOnly = true;
            Telefono.Width = 170;
            // 
            // Direccion
            // 
            Direccion.DataPropertyName = "Direccion";
            Direccion.HeaderText = "Dirección";
            Direccion.Name = "Direccion";
            Direccion.ReadOnly = true;
            Direccion.Width = 230;
            // 
            // Saldo
            // 
            Saldo.DataPropertyName = "Saldo";
            Saldo.HeaderText = "Saldo";
            Saldo.Name = "Saldo";
            Saldo.ReadOnly = true;
            Saldo.Width = 160;
            // 
            // frmNuevoCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1451, 780);
            Controls.Add(groupBox1);
            Controls.Add(grpDatos);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNuevoCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ver y crear clientes";
            Load += frmNuevoCliente_Load;
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private TextBox txtDireccion;
        private Button cmdAgregar;
        private GroupBox groupBox1;
        private Button cmdTodos;
        private Button cmdDeudores;
        private DataGridView dgvGrilla;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewTextBoxColumn Direccion;
        private DataGridViewTextBoxColumn Saldo;
    }
}