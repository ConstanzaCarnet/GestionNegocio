namespace GestionApp.Vistas
{
    partial class frmAyuda
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
            lblPasos = new Label();
            lblTitulo = new Label();
            lblAyuda = new Label();
            lnkRedirecion = new LinkLabel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblPasos);
            groupBox1.Controls.Add(lblTitulo);
            groupBox1.Controls.Add(lblAyuda);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(598, 431);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // lblPasos
            // 
            lblPasos.Location = new Point(22, 157);
            lblPasos.Name = "lblPasos";
            lblPasos.Size = new Size(552, 253);
            lblPasos.TabIndex = 3;
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new Point(22, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(552, 57);
            lblTitulo.TabIndex = 2;
            // 
            // lblAyuda
            // 
            lblAyuda.Location = new Point(22, 79);
            lblAyuda.Name = "lblAyuda";
            lblAyuda.Size = new Size(552, 78);
            lblAyuda.TabIndex = 1;
            // 
            // lnkRedirecion
            // 
            lnkRedirecion.Location = new Point(12, 446);
            lnkRedirecion.Name = "lnkRedirecion";
            lnkRedirecion.Size = new Size(469, 24);
            lnkRedirecion.TabIndex = 1;
            lnkRedirecion.LinkClicked += lnkRedirecion_LinkClicked;
            // 
            // frmAyuda
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(620, 479);
            Controls.Add(lnkRedirecion);
            Controls.Add(groupBox1);
            Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAyuda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ayuda";
            Load += frmAyuda_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblAyuda;
        private Label lblTitulo;
        private Label lblPasos;
        private LinkLabel lnkRedirecion;
    }
}