namespace GestionApp
{
    partial class frmHome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            sistemaToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            salirToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            nuevoProductoToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripSeparator();
            verTodosToolStripMenuItem = new ToolStripMenuItem();
            buscarProductoToolStripMenuItem = new ToolStripMenuItem();
            porCategoríasToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripSeparator();
            catálogosToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            nuevoClienteToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            comprasDeUnClienteToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            filtrarClienteToolStripMenuItem = new ToolStripMenuItem();
            cargarPagoToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            cargarNuevaVentaToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            verTodasToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripSeparator();
            balancesToolStripMenuItem = new ToolStripMenuItem();
            categoríasToolStripMenuItem = new ToolStripMenuItem();
            nuevaCategoríaToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripSeparator();
            verCategoríasToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.GripMargin = new Padding(4, 4, 0, 4);
            menuStrip1.Items.AddRange(new ToolStripItem[] { sistemaToolStripMenuItem, categoríasToolStripMenuItem, productosToolStripMenuItem, clientesToolStripMenuItem, ventasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1279, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            sistemaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { acercaDeToolStripMenuItem, toolStripMenuItem1, salirToolStripMenuItem });
            sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            sistemaToolStripMenuItem.Size = new Size(60, 20);
            sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(135, 22);
            acercaDeToolStripMenuItem.Text = "Acerca de...";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(132, 6);
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(135, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevoProductoToolStripMenuItem, toolStripMenuItem5, verTodosToolStripMenuItem, buscarProductoToolStripMenuItem, porCategoríasToolStripMenuItem, toolStripMenuItem9, catálogosToolStripMenuItem });
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(73, 20);
            productosToolStripMenuItem.Text = "Productos";
            // 
            // nuevoProductoToolStripMenuItem
            // 
            nuevoProductoToolStripMenuItem.Name = "nuevoProductoToolStripMenuItem";
            nuevoProductoToolStripMenuItem.Size = new Size(180, 22);
            nuevoProductoToolStripMenuItem.Text = "Nuevo producto...";
            nuevoProductoToolStripMenuItem.Click += nuevoProductoToolStripMenuItem_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(177, 6);
            // 
            // verTodosToolStripMenuItem
            // 
            verTodosToolStripMenuItem.Name = "verTodosToolStripMenuItem";
            verTodosToolStripMenuItem.Size = new Size(180, 22);
            verTodosToolStripMenuItem.Text = "Ver todos...";
            verTodosToolStripMenuItem.Click += verTodosToolStripMenuItem_Click;
            // 
            // buscarProductoToolStripMenuItem
            // 
            buscarProductoToolStripMenuItem.Name = "buscarProductoToolStripMenuItem";
            buscarProductoToolStripMenuItem.Size = new Size(180, 22);
            buscarProductoToolStripMenuItem.Text = "Buscar producto...";
            buscarProductoToolStripMenuItem.Click += buscarProductoToolStripMenuItem_Click;
            // 
            // porCategoríasToolStripMenuItem
            // 
            porCategoríasToolStripMenuItem.Name = "porCategoríasToolStripMenuItem";
            porCategoríasToolStripMenuItem.Size = new Size(180, 22);
            porCategoríasToolStripMenuItem.Text = "Por categorías...";
            porCategoríasToolStripMenuItem.Click += porCategoríasToolStripMenuItem_Click;
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(177, 6);
            // 
            // catálogosToolStripMenuItem
            // 
            catálogosToolStripMenuItem.Name = "catálogosToolStripMenuItem";
            catálogosToolStripMenuItem.Size = new Size(180, 22);
            catálogosToolStripMenuItem.Text = "Catálogos...";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevoClienteToolStripMenuItem, toolStripMenuItem3, comprasDeUnClienteToolStripMenuItem, toolStripMenuItem4, filtrarClienteToolStripMenuItem, cargarPagoToolStripMenuItem });
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(61, 20);
            clientesToolStripMenuItem.Text = "Clientes";
            // 
            // nuevoClienteToolStripMenuItem
            // 
            nuevoClienteToolStripMenuItem.Name = "nuevoClienteToolStripMenuItem";
            nuevoClienteToolStripMenuItem.Size = new Size(180, 22);
            nuevoClienteToolStripMenuItem.Text = "Nuevo cliente...";
            nuevoClienteToolStripMenuItem.Click += nuevoClienteToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(177, 6);
            // 
            // comprasDeUnClienteToolStripMenuItem
            // 
            comprasDeUnClienteToolStripMenuItem.Name = "comprasDeUnClienteToolStripMenuItem";
            comprasDeUnClienteToolStripMenuItem.Size = new Size(180, 22);
            comprasDeUnClienteToolStripMenuItem.Text = "Ver todos";
            comprasDeUnClienteToolStripMenuItem.Click += comprasDeUnClienteToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(177, 6);
            // 
            // filtrarClienteToolStripMenuItem
            // 
            filtrarClienteToolStripMenuItem.Name = "filtrarClienteToolStripMenuItem";
            filtrarClienteToolStripMenuItem.Size = new Size(180, 22);
            filtrarClienteToolStripMenuItem.Text = "Buscar cliente...";
            filtrarClienteToolStripMenuItem.Click += filtrarClienteToolStripMenuItem_Click;
            // 
            // cargarPagoToolStripMenuItem
            // 
            cargarPagoToolStripMenuItem.Name = "cargarPagoToolStripMenuItem";
            cargarPagoToolStripMenuItem.Size = new Size(180, 22);
            cargarPagoToolStripMenuItem.Text = "Cargar pago...";
            cargarPagoToolStripMenuItem.Click += cargarPagoToolStripMenuItem_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cargarNuevaVentaToolStripMenuItem, toolStripMenuItem2, verTodasToolStripMenuItem, toolStripMenuItem8, balancesToolStripMenuItem });
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(53, 20);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // cargarNuevaVentaToolStripMenuItem
            // 
            cargarNuevaVentaToolStripMenuItem.Name = "cargarNuevaVentaToolStripMenuItem";
            cargarNuevaVentaToolStripMenuItem.Size = new Size(149, 22);
            cargarNuevaVentaToolStripMenuItem.Text = "Nueva venta...";
            cargarNuevaVentaToolStripMenuItem.Click += cargarNuevaVentaToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(146, 6);
            // 
            // verTodasToolStripMenuItem
            // 
            verTodasToolStripMenuItem.Name = "verTodasToolStripMenuItem";
            verTodasToolStripMenuItem.Size = new Size(149, 22);
            verTodasToolStripMenuItem.Text = "Ver todas...";
            verTodasToolStripMenuItem.Click += verTodasToolStripMenuItem_Click;
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(146, 6);
            // 
            // balancesToolStripMenuItem
            // 
            balancesToolStripMenuItem.Name = "balancesToolStripMenuItem";
            balancesToolStripMenuItem.Size = new Size(149, 22);
            balancesToolStripMenuItem.Text = "Balances...";
            // 
            // categoríasToolStripMenuItem
            // 
            categoríasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevaCategoríaToolStripMenuItem, toolStripMenuItem6, verCategoríasToolStripMenuItem });
            categoríasToolStripMenuItem.Name = "categoríasToolStripMenuItem";
            categoríasToolStripMenuItem.Size = new Size(75, 20);
            categoríasToolStripMenuItem.Text = "Categorías";
            // 
            // nuevaCategoríaToolStripMenuItem
            // 
            nuevaCategoríaToolStripMenuItem.Name = "nuevaCategoríaToolStripMenuItem";
            nuevaCategoríaToolStripMenuItem.Size = new Size(180, 22);
            nuevaCategoríaToolStripMenuItem.Text = "Nueva categoría...";
            nuevaCategoríaToolStripMenuItem.Click += nuevaCategoríaToolStripMenuItem_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(177, 6);
            // 
            // verCategoríasToolStripMenuItem
            // 
            verCategoríasToolStripMenuItem.Name = "verCategoríasToolStripMenuItem";
            verCategoríasToolStripMenuItem.Size = new Size(180, 22);
            verCategoríasToolStripMenuItem.Text = "Ver categorías...";
            verCategoríasToolStripMenuItem.Click += verCategoríasToolStripMenuItem_Click;
            // 
            // frmHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1279, 571);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmHome";
            Text = "Home";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem sistemaToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem cargarNuevaVentaToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem verTodasToolStripMenuItem;
        private ToolStripMenuItem nuevoClienteToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem comprasDeUnClienteToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem filtrarClienteToolStripMenuItem;
        private ToolStripMenuItem nuevoProductoToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem verTodosToolStripMenuItem;
        private ToolStripMenuItem buscarProductoToolStripMenuItem;
        private ToolStripMenuItem porCategoríasToolStripMenuItem;
        private ToolStripMenuItem catálogosToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripMenuItem balancesToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem9;
        private ToolStripMenuItem cargarPagoToolStripMenuItem;
        private ToolStripMenuItem categoríasToolStripMenuItem;
        private ToolStripMenuItem nuevaCategoríaToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripMenuItem verCategoríasToolStripMenuItem;
    }
}
