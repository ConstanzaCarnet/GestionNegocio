namespace GestionApp
{
    partial class frmCargarPago
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
            cmbCliente = new ComboBox();
            label2 = new Label();
            cmdCargar = new Button();
            txtPCompra = new TextBox();
            label6 = new Label();
            label4 = new Label();
            cmbFormaPago = new ComboBox();
            grpDatos.SuspendLayout();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(cmbFormaPago);
            grpDatos.Controls.Add(cmbCliente);
            grpDatos.Controls.Add(label2);
            grpDatos.Controls.Add(cmdCargar);
            grpDatos.Controls.Add(txtPCompra);
            grpDatos.Controls.Add(label6);
            grpDatos.Controls.Add(label4);
            grpDatos.Location = new Point(12, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(479, 243);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Cargar datos";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(136, 42);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(317, 26);
            cmbCliente.TabIndex = 31;
            // 
            // label2
            // 
            label2.Location = new Point(36, 45);
            label2.Name = "label2";
            label2.Size = new Size(94, 28);
            label2.TabIndex = 30;
            label2.Text = "Cliente:";
            // 
            // cmdCargar
            // 
            cmdCargar.BackColor = Color.Gainsboro;
            cmdCargar.FlatStyle = FlatStyle.Popup;
            cmdCargar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdCargar.Location = new Point(243, 184);
            cmdCargar.Name = "cmdCargar";
            cmdCargar.Size = new Size(210, 42);
            cmdCargar.TabIndex = 27;
            cmdCargar.Text = "CARGAR";
            cmdCargar.UseVisualStyleBackColor = false;
            // 
            // txtPCompra
            // 
            txtPCompra.Location = new Point(114, 85);
            txtPCompra.Multiline = true;
            txtPCompra.Name = "txtPCompra";
            txtPCompra.Size = new Size(339, 23);
            txtPCompra.TabIndex = 23;
            // 
            // label6
            // 
            label6.Location = new Point(36, 85);
            label6.Name = "label6";
            label6.Size = new Size(94, 28);
            label6.TabIndex = 19;
            label6.Text = "Monto";
            // 
            // label4
            // 
            label4.Location = new Point(36, 133);
            label4.Name = "label4";
            label4.Size = new Size(136, 24);
            label4.TabIndex = 17;
            label4.Text = "Forma de pago:";
            // 
            // cmbFormaPago
            // 
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Location = new Point(196, 130);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(257, 26);
            cmbFormaPago.TabIndex = 38;
            // 
            // frmCargarPago
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(505, 266);
            Controls.Add(grpDatos);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCargarPago";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cargar pago";
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private Button cmdCargar;
        private TextBox txtPCompra;
        private Label label6;
        private Label label4;
        private ComboBox cmbCliente;
        private Label label2;
        private ComboBox cmbFormaPago;
    }
}