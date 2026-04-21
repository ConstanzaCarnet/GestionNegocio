namespace GestionApp.Vistas
{
    partial class frmNuevaCategoria
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
            cmdCrear = new Button();
            txtDescripcion = new TextBox();
            txtNombre = new TextBox();
            label6 = new Label();
            label4 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdCrear);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(659, 300);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de la nueva categoría";
            // 
            // cmdCrear
            // 
            cmdCrear.BackColor = Color.Gainsboro;
            cmdCrear.Enabled = false;
            cmdCrear.FlatStyle = FlatStyle.Popup;
            cmdCrear.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdCrear.Location = new Point(426, 230);
            cmdCrear.Name = "cmdCrear";
            cmdCrear.Size = new Size(210, 42);
            cmdCrear.TabIndex = 32;
            cmdCrear.Text = "CREAR";
            cmdCrear.UseVisualStyleBackColor = false;
            cmdCrear.Click += cmdCrear_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(186, 90);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(450, 113);
            txtDescripcion.TabIndex = 31;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(186, 49);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(450, 23);
            txtNombre.TabIndex = 30;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // label6
            // 
            label6.Location = new Point(39, 49);
            label6.Name = "label6";
            label6.Size = new Size(141, 28);
            label6.TabIndex = 29;
            label6.Text = "Nombre:";
            // 
            // label4
            // 
            label4.Location = new Point(39, 93);
            label4.Name = "label4";
            label4.Size = new Size(121, 24);
            label4.TabIndex = 28;
            label4.Text = "Descripción:";
            // 
            // frmNuevaCategoria
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(683, 318);
            Controls.Add(groupBox1);
            Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNuevaCategoria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva categoría";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button cmdCrear;
        private TextBox txtDescripcion;
        private TextBox txtNombre;
        private Label label6;
        private Label label4;
    }
}