namespace GestionApp.Vistas
{
    partial class frmVerCategorías
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvGrilla = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            cmdModificar = new DataGridViewButtonColumn();
            cmdEliminar = new DataGridViewButtonColumn();
            grpCategorias = new GroupBox();
            groupBox1 = new GroupBox();
            cmdCrear = new Button();
            txtDescripcion = new TextBox();
            txtNombre = new TextBox();
            label6 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            grpCategorias.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvGrilla
            // 
            dgvGrilla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvGrilla.ColumnHeadersHeight = 35;
            dgvGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvGrilla.Columns.AddRange(new DataGridViewColumn[] { Nombre, Descripcion, cmdModificar, cmdEliminar });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvGrilla.DefaultCellStyle = dataGridViewCellStyle2;
            dgvGrilla.Location = new Point(22, 25);
            dgvGrilla.Name = "dgvGrilla";
            dgvGrilla.ReadOnly = true;
            dgvGrilla.RowHeadersVisible = false;
            dgvGrilla.ScrollBars = ScrollBars.Vertical;
            dgvGrilla.Size = new Size(1259, 267);
            dgvGrilla.TabIndex = 38;
            dgvGrilla.CellContentClick += dgvGrilla_CellContentClick;
            // 
            // Nombre
            // 
            Nombre.DataPropertyName = "Nombre";
            Nombre.FillWeight = 79.617836F;
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 250;
            // 
            // Descripcion
            // 
            Descripcion.DataPropertyName = "Descripcion";
            Descripcion.FillWeight = 272.761749F;
            Descripcion.HeaderText = "Descripción";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            Descripcion.Width = 800;
            // 
            // cmdModificar
            // 
            cmdModificar.DataPropertyName = "cmdModificar";
            cmdModificar.FillWeight = 20.4579811F;
            cmdModificar.HeaderText = "Modificar";
            cmdModificar.Name = "cmdModificar";
            cmdModificar.ReadOnly = true;
            cmdModificar.Text = "*";
            cmdModificar.UseColumnTextForButtonValue = true;
            // 
            // cmdEliminar
            // 
            cmdEliminar.DataPropertyName = "cmdEliminar";
            cmdEliminar.FillWeight = 27.1624355F;
            cmdEliminar.HeaderText = "Eliminar";
            cmdEliminar.Name = "cmdEliminar";
            cmdEliminar.ReadOnly = true;
            cmdEliminar.Text = "X";
            cmdEliminar.UseColumnTextForButtonValue = true;
            // 
            // grpCategorias
            // 
            grpCategorias.Controls.Add(dgvGrilla);
            grpCategorias.Location = new Point(12, 288);
            grpCategorias.Name = "grpCategorias";
            grpCategorias.Size = new Size(1298, 314);
            grpCategorias.TabIndex = 39;
            grpCategorias.TabStop = false;
            grpCategorias.Text = "Categorias";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdCrear);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(17, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1292, 270);
            groupBox1.TabIndex = 40;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de la nueva categoría";
            // 
            // cmdCrear
            // 
            cmdCrear.BackColor = Color.Gainsboro;
            cmdCrear.Enabled = false;
            cmdCrear.FlatStyle = FlatStyle.Popup;
            cmdCrear.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdCrear.Location = new Point(888, 203);
            cmdCrear.Name = "cmdCrear";
            cmdCrear.Size = new Size(210, 42);
            cmdCrear.TabIndex = 32;
            cmdCrear.Text = "CREAR";
            cmdCrear.UseVisualStyleBackColor = false;
            cmdCrear.Click += cmdCrear_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(313, 90);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(785, 91);
            txtDescripcion.TabIndex = 31;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(313, 54);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(785, 23);
            txtNombre.TabIndex = 30;
            txtNombre.TextChanged += txtNombre_TextChanged_1;
            // 
            // label6
            // 
            label6.Location = new Point(149, 57);
            label6.Name = "label6";
            label6.Size = new Size(141, 20);
            label6.TabIndex = 29;
            label6.Text = "Nombre:";
            // 
            // label4
            // 
            label4.Location = new Point(149, 93);
            label4.Name = "label4";
            label4.Size = new Size(121, 24);
            label4.TabIndex = 28;
            label4.Text = "Descripción:";
            // 
            // frmVerCategorías
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1321, 610);
            Controls.Add(groupBox1);
            Controls.Add(grpCategorias);
            Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmVerCategorías";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Todas las categorías";
            Load += frmVerCategorías_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            grpCategorias.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvGrilla;
        private GroupBox grpCategorias;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewButtonColumn cmdModificar;
        private DataGridViewButtonColumn cmdEliminar;
        private GroupBox groupBox1;
        private Button cmdCrear;
        private TextBox txtDescripcion;
        private TextBox txtNombre;
        private Label label6;
        private Label label4;
    }
}