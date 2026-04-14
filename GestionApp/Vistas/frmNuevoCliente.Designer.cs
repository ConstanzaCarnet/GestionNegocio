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
            grpDatos.SuspendLayout();
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
            grpDatos.Size = new Size(705, 242);
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
            cmdAgregar.Location = new Point(121, 181);
            cmdAgregar.Name = "cmdAgregar";
            cmdAgregar.Size = new Size(210, 42);
            cmdAgregar.TabIndex = 27;
            cmdAgregar.Text = "AGREGAR";
            cmdAgregar.UseVisualStyleBackColor = false;
            cmdAgregar.Click += cmdAgregar_Click;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(121, 129);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(568, 23);
            txtDireccion.TabIndex = 26;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(442, 82);
            txtTelefono.Multiline = true;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(247, 23);
            txtTelefono.TabIndex = 25;
            txtTelefono.TextChanged += textTelefono_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(109, 82);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(196, 23);
            txtEmail.TabIndex = 23;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(132, 42);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(173, 23);
            txtNombre.TabIndex = 22;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(435, 42);
            txtApellido.Multiline = true;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(254, 23);
            txtApellido.TabIndex = 20;
            txtApellido.TextChanged += txtApellido_TextChanged;
            // 
            // label6
            // 
            label6.Location = new Point(41, 85);
            label6.Name = "label6";
            label6.Size = new Size(141, 28);
            label6.TabIndex = 19;
            label6.Text = "Email:";
            // 
            // label5
            // 
            label5.Location = new Point(352, 85);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 18;
            label5.Text = "Teléfono:";
            // 
            // label4
            // 
            label4.Location = new Point(41, 132);
            label4.Name = "label4";
            label4.Size = new Size(94, 24);
            label4.TabIndex = 17;
            label4.Text = "Dirección:";
            // 
            // label3
            // 
            label3.Location = new Point(352, 45);
            label3.Name = "label3";
            label3.Size = new Size(64, 28);
            label3.TabIndex = 16;
            label3.Text = "Apellido:";
            // 
            // label1
            // 
            label1.Location = new Point(41, 45);
            label1.Name = "label1";
            label1.Size = new Size(94, 28);
            label1.TabIndex = 14;
            label1.Text = "Nombre:";
            // 
            // frmNuevoCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(730, 270);
            Controls.Add(grpDatos);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNuevoCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nuevo cliente";
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
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
    }
}