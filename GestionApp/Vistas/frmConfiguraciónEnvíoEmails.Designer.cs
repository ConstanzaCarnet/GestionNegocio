namespace GestionApp.Vistas
{
    partial class frmConfiguraciónEnvíoEmails
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
            cmdProbar = new Button();
            cmdGuardar = new Button();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            label2 = new Label();
            label1 = new Label();
            lnkAyuda = new LinkLabel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdProbar);
            groupBox1.Controls.Add(cmdGuardar);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(13, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(592, 223);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Completa con tus datos";
            // 
            // cmdProbar
            // 
            cmdProbar.BackColor = Color.Lavender;
            cmdProbar.Enabled = false;
            cmdProbar.FlatStyle = FlatStyle.Popup;
            cmdProbar.Location = new Point(33, 157);
            cmdProbar.Name = "cmdProbar";
            cmdProbar.Size = new Size(208, 40);
            cmdProbar.TabIndex = 5;
            cmdProbar.Text = "Probar";
            cmdProbar.UseVisualStyleBackColor = false;
            cmdProbar.Click += cmdProbar_Click;
            // 
            // cmdGuardar
            // 
            cmdGuardar.BackColor = Color.Lavender;
            cmdGuardar.Enabled = false;
            cmdGuardar.FlatStyle = FlatStyle.Popup;
            cmdGuardar.Location = new Point(346, 157);
            cmdGuardar.Name = "cmdGuardar";
            cmdGuardar.Size = new Size(208, 40);
            cmdGuardar.TabIndex = 4;
            cmdGuardar.Text = "Guargar";
            cmdGuardar.UseVisualStyleBackColor = false;
            cmdGuardar.Click += cmdGuardar_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(321, 83);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(233, 26);
            txtPassword.TabIndex = 3;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(146, 41);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(408, 26);
            txtEmail.TabIndex = 2;
            txtEmail.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.Location = new Point(56, 86);
            label2.Name = "label2";
            label2.Size = new Size(274, 28);
            label2.TabIndex = 1;
            label2.Text = "Contraseña(para aplicaciones):";
            // 
            // label1
            // 
            label1.Location = new Point(56, 44);
            label1.Name = "label1";
            label1.Size = new Size(111, 28);
            label1.TabIndex = 0;
            label1.Text = "Email:";
            // 
            // lnkAyuda
            // 
            lnkAyuda.AccessibleDescription = "Ayuda";
            lnkAyuda.AccessibleRole = AccessibleRole.HelpBalloon;
            lnkAyuda.AutoSize = true;
            lnkAyuda.Location = new Point(13, 265);
            lnkAyuda.Name = "lnkAyuda";
            lnkAyuda.Size = new Size(342, 18);
            lnkAyuda.TabIndex = 5;
            lnkAyuda.TabStop = true;
            lnkAyuda.Text = "Cómo creo mi contraseña para aplicaciones?";
            lnkAyuda.LinkClicked += lnkAyuda_LinkClicked;
            // 
            // frmConfiguraciónEnvíoEmails
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(618, 296);
            Controls.Add(lnkAyuda);
            Controls.Add(groupBox1);
            Enabled = true;
            Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmConfiguraciónEnvíoEmails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configura el sistema para enviar emails";
            Load += frmConfiguraciónEnvíoEmails_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private LinkLabel lnkAyuda;
        private Button cmdGuardar;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private Label label2;
        private Button cmdProbar;
    }
}