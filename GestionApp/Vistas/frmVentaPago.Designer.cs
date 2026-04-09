namespace GestionApp
{
    partial class frmVentaPago
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
            cmdFinalizar = new Button();
            cmbCuotas = new ComboBox();
            label10 = new Label();
            cmbFormaPago = new ComboBox();
            label9 = new Label();
            label7 = new Label();
            label4 = new Label();
            lblCliente = new Label();
            cmdCancelar = new Button();
            lblMontoTotal = new Label();
            lblPorPago = new Label();
            label5 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblPorPago);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblMontoTotal);
            groupBox1.Controls.Add(cmdCancelar);
            groupBox1.Controls.Add(lblCliente);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbCuotas);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(cmbFormaPago);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cmdFinalizar);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(454, 335);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Finalizar venta";
            // 
            // cmdFinalizar
            // 
            cmdFinalizar.BackColor = Color.Gainsboro;
            cmdFinalizar.FlatStyle = FlatStyle.Popup;
            cmdFinalizar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdFinalizar.Location = new Point(286, 279);
            cmdFinalizar.Name = "cmdFinalizar";
            cmdFinalizar.Size = new Size(152, 42);
            cmdFinalizar.TabIndex = 28;
            cmdFinalizar.Text = "FINALIZAR";
            cmdFinalizar.UseVisualStyleBackColor = false;
            // 
            // cmbCuotas
            // 
            cmbCuotas.FormattingEnabled = true;
            cmbCuotas.Location = new Point(152, 173);
            cmbCuotas.Name = "cmbCuotas";
            cmbCuotas.Size = new Size(285, 26);
            cmbCuotas.TabIndex = 39;
            // 
            // label10
            // 
            label10.Location = new Point(34, 176);
            label10.Name = "label10";
            label10.Size = new Size(99, 28);
            label10.TabIndex = 38;
            label10.Text = "Cuotas:";
            // 
            // cmbFormaPago
            // 
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Location = new Point(181, 126);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(257, 26);
            cmbFormaPago.TabIndex = 37;
            // 
            // label9
            // 
            label9.Location = new Point(34, 129);
            label9.Name = "label9";
            label9.Size = new Size(141, 28);
            label9.TabIndex = 34;
            label9.Text = "Forma de pago:";
            // 
            // label7
            // 
            label7.Location = new Point(34, 81);
            label7.Name = "label7";
            label7.Size = new Size(108, 20);
            label7.TabIndex = 32;
            label7.Text = "Monto total:";
            // 
            // label4
            // 
            label4.Location = new Point(34, 33);
            label4.Name = "label4";
            label4.Size = new Size(94, 27);
            label4.TabIndex = 40;
            label4.Text = "Cliente:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCliente
            // 
            lblCliente.BorderStyle = BorderStyle.Fixed3D;
            lblCliente.FlatStyle = FlatStyle.Popup;
            lblCliente.Location = new Point(134, 32);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(303, 28);
            lblCliente.TabIndex = 41;
            // 
            // cmdCancelar
            // 
            cmdCancelar.BackColor = Color.Gainsboro;
            cmdCancelar.FlatStyle = FlatStyle.Popup;
            cmdCancelar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdCancelar.Location = new Point(12, 279);
            cmdCancelar.Name = "cmdCancelar";
            cmdCancelar.Size = new Size(152, 42);
            cmdCancelar.TabIndex = 42;
            cmdCancelar.Text = "CANCELAR";
            cmdCancelar.UseVisualStyleBackColor = false;
            // 
            // lblMontoTotal
            // 
            lblMontoTotal.BorderStyle = BorderStyle.Fixed3D;
            lblMontoTotal.FlatStyle = FlatStyle.Popup;
            lblMontoTotal.Location = new Point(170, 73);
            lblMontoTotal.Name = "lblMontoTotal";
            lblMontoTotal.Size = new Size(267, 28);
            lblMontoTotal.TabIndex = 43;
            // 
            // lblPorPago
            // 
            lblPorPago.BorderStyle = BorderStyle.Fixed3D;
            lblPorPago.FlatStyle = FlatStyle.Popup;
            lblPorPago.Location = new Point(196, 217);
            lblPorPago.Name = "lblPorPago";
            lblPorPago.Size = new Size(241, 28);
            lblPorPago.TabIndex = 45;
            // 
            // label5
            // 
            label5.Location = new Point(34, 217);
            label5.Name = "label5";
            label5.Size = new Size(141, 27);
            label5.TabIndex = 44;
            label5.Text = "Monto por pago:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmVentaPago
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(477, 356);
            Controls.Add(groupBox1);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmVentaPago";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVentaPago";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button cmdFinalizar;
        private ComboBox cmbCuotas;
        private Label label10;
        private ComboBox cmbFormaPago;
        private Label label9;
        private Label label7;
        private Label label4;
        private Label lblCliente;
        private Button cmdCancelar;
        private Label lblMontoTotal;
        private Label lblPorPago;
        private Label label5;
    }
}