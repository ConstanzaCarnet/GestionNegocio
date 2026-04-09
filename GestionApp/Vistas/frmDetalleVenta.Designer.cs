namespace GestionApp
{
    partial class frmDetalleVenta
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
            dgvGrilla = new DataGridView();
            lblCliente = new Label();
            label7 = new Label();
            cmdEmail = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(cmdEmail);
            groupBox1.Controls.Add(lblCliente);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(dgvGrilla);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(654, 476);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información";
            // 
            // dgvGrilla
            // 
            dgvGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrilla.Location = new Point(20, 89);
            dgvGrilla.Name = "dgvGrilla";
            dgvGrilla.ReadOnly = true;
            dgvGrilla.RowHeadersVisible = false;
            dgvGrilla.ScrollBars = ScrollBars.Vertical;
            dgvGrilla.Size = new Size(617, 283);
            dgvGrilla.TabIndex = 37;
            // 
            // lblCliente
            // 
            lblCliente.BorderStyle = BorderStyle.Fixed3D;
            lblCliente.FlatStyle = FlatStyle.Popup;
            lblCliente.Location = new Point(86, 45);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(250, 28);
            lblCliente.TabIndex = 39;
            // 
            // label7
            // 
            label7.Location = new Point(20, 53);
            label7.Name = "label7";
            label7.Size = new Size(108, 20);
            label7.TabIndex = 38;
            label7.Text = "Cliente:";
            // 
            // cmdEmail
            // 
            cmdEmail.BackColor = Color.Gainsboro;
            cmdEmail.FlatStyle = FlatStyle.Popup;
            cmdEmail.Location = new Point(484, 407);
            cmdEmail.Name = "cmdEmail";
            cmdEmail.Size = new Size(153, 53);
            cmdEmail.TabIndex = 40;
            cmdEmail.Text = "MANDAR MENSAJE";
            cmdEmail.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Gainsboro;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(20, 407);
            button2.Name = "button2";
            button2.Size = new Size(153, 53);
            button2.TabIndex = 42;
            button2.Text = "DESCARGAR PDF";
            button2.UseVisualStyleBackColor = false;
            // 
            // frmDetalleVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(677, 498);
            Controls.Add(groupBox1);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmDetalleVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de la venta";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvGrilla;
        private Label lblCliente;
        private Label label7;
        private Button button2;
        private Button cmdEmail;
    }
}