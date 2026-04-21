namespace GestionApp
{
    partial class frmVerClientes
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
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(cmdTodos);
            grpDatos.Controls.Add(cmdDeudores);
            grpDatos.Controls.Add(dgvGrilla);
            grpDatos.Location = new Point(12, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(1421, 624);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Todos los clientes";
            // 
            // cmdTodos
            // 
            cmdTodos.BackColor = Color.Gainsboro;
            cmdTodos.FlatStyle = FlatStyle.Popup;
            cmdTodos.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdTodos.Location = new Point(24, 577);
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
            cmdDeudores.Location = new Point(1210, 577);
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
            dgvGrilla.Size = new Size(1380, 516);
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
            // frmVerClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1445, 648);
            Controls.Add(grpDatos);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmVerClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ver todos los clientes";
            Load += frmVerClientes_Load;
            grpDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private Button cmdDeudores;
        private DataGridView dgvGrilla;
        private Button cmdTodos;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewTextBoxColumn Direccion;
        private DataGridViewTextBoxColumn Saldo;
    }
}