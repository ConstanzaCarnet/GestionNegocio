namespace GestionApp.Vistas
{
    partial class frmCatalogos
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
            groupBox1 = new GroupBox();
            txtCatalogo = new TextBox();
            amdExaminar = new Button();
            cmdSeleccionarTodos = new Button();
            dgvGrilla = new DataGridView();
            cmdEnviar = new Button();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            Seleccionado = new DataGridViewCheckBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCatalogo);
            groupBox1.Controls.Add(amdExaminar);
            groupBox1.Controls.Add(cmdSeleccionarTodos);
            groupBox1.Controls.Add(dgvGrilla);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1113, 420);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Envío de catalogo a clientes";
            //
            // txtCatalogo
            //
            txtCatalogo.Enabled = false;
            txtCatalogo.Location = new Point(620, 366);
            txtCatalogo.Name = "txtCatalogo";
            txtCatalogo.Size = new Size(251, 26);
            txtCatalogo.TabIndex = 39;
            txtCatalogo.Text = "Cargar catalogo...";
            //
            // amdExaminar
            //
            amdExaminar.BackColor = Color.Gainsboro;
            amdExaminar.FlatStyle = FlatStyle.Popup;
            amdExaminar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            amdExaminar.Location = new Point(900, 365);
            amdExaminar.Name = "amdExaminar";
            amdExaminar.Size = new Size(194, 26);
            amdExaminar.TabIndex = 38;
            amdExaminar.Text = "EXAMINAR";
            amdExaminar.UseVisualStyleBackColor = false;
            amdExaminar.Click += amdExaminar_Click;
            //
            // cmdSeleccionarTodos
            // 
            cmdSeleccionarTodos.BackColor = Color.Gainsboro;
            cmdSeleccionarTodos.FlatStyle = FlatStyle.Popup;
            cmdSeleccionarTodos.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdSeleccionarTodos.Location = new Point(16, 365);
            cmdSeleccionarTodos.Name = "cmdSeleccionarTodos";
            cmdSeleccionarTodos.Size = new Size(201, 26);
            cmdSeleccionarTodos.TabIndex = 36;
            cmdSeleccionarTodos.Text = "SELECCIONAR TODOS";
            cmdSeleccionarTodos.UseVisualStyleBackColor = false;
            cmdSeleccionarTodos.Click += cmdSeleccionarTodos_Click;
            // 
            // dgvGrilla
            // 
            dgvGrilla.AllowUserToAddRows = false;
            dgvGrilla.AllowUserToDeleteRows = false;
            dgvGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrilla.Columns.AddRange(new DataGridViewColumn[] { Nombre, Apellido, Email, Telefono, Seleccionado });
            dgvGrilla.Location = new Point(16, 37);
            dgvGrilla.Name = "dgvGrilla";
            dgvGrilla.RowHeadersVisible = false;
            dgvGrilla.ScrollBars = ScrollBars.Vertical;
            dgvGrilla.Size = new Size(1078, 310);
            dgvGrilla.TabIndex = 2;
            // 
            // cmdEnviar
            // 
            cmdEnviar.BackColor = Color.Gainsboro;
            cmdEnviar.FlatStyle = FlatStyle.Popup;
            cmdEnviar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdEnviar.Location = new Point(931, 449);
            cmdEnviar.Name = "cmdEnviar";
            cmdEnviar.Size = new Size(194, 26);
            cmdEnviar.TabIndex = 37;
            cmdEnviar.Text = "ENVIAR";
            cmdEnviar.UseVisualStyleBackColor = false;
            cmdEnviar.Click += cmdEnviar_Click;
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
            // Seleccionado
            // 
            Seleccionado.FlatStyle = FlatStyle.Popup;
            Seleccionado.HeaderText = "Seleccionar";
            Seleccionado.Name = "Seleccionado";
            Seleccionado.ReadOnly = false;
            // 
            // frmCatalogos
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1135, 490);
            Controls.Add(groupBox1);
            Controls.Add(cmdEnviar);
            Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCatalogos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catalogos";
            Load += frmCatalogos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvGrilla;
        private Button cmdSeleccionarTodos;
        private Button cmdEnviar;
        private TextBox txtCatalogo;
        private Button amdExaminar;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewCheckBoxColumn Seleccionado;
    }
}