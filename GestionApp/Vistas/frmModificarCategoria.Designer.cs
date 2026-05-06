namespace GestionApp.Vistas
{
    partial class frmModificarCategoria
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
            txtDescripcion = new TextBox();
            txtNombre = new TextBox();
            label4 = new Label();
            label2 = new Label();
            cmdGuardar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmdGuardar);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(604, 311);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(153, 89);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(415, 118);
            txtDescripcion.TabIndex = 44;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(135, 46);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(433, 23);
            txtNombre.TabIndex = 43;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // label4
            // 
            label4.Location = new Point(35, 89);
            label4.Name = "label4";
            label4.Size = new Size(101, 24);
            label4.TabIndex = 42;
            label4.Text = "Descripción:";
            // 
            // label2
            // 
            label2.Location = new Point(35, 49);
            label2.Name = "label2";
            label2.Size = new Size(94, 28);
            label2.TabIndex = 41;
            label2.Text = "Nombre:";
            // 
            // cmdGuardar
            // 
            cmdGuardar.BackColor = Color.Gainsboro;
            cmdGuardar.Enabled = false;
            cmdGuardar.FlatStyle = FlatStyle.Popup;
            cmdGuardar.Location = new Point(415, 236);
            cmdGuardar.Name = "cmdGuardar";
            cmdGuardar.Size = new Size(153, 53);
            cmdGuardar.TabIndex = 40;
            cmdGuardar.Text = "GUARDAR";
            cmdGuardar.UseVisualStyleBackColor = false;
            cmdGuardar.Click += cmdGuardar_Click;
            // 
            // frmModificarCategoria
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(625, 329);
            Controls.Add(groupBox1);
            Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmModificarCategoria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar categoría";
            Load += frmModificarCategoria_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button cmdGuardar;
        private TextBox txtDescripcion;
        private TextBox txtNombre;
        private Label label4;
        private Label label2;
    }
}