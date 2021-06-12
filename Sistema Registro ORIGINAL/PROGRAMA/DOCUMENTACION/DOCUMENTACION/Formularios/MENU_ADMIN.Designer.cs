namespace DOCUMENTACION.Formularios
{
    partial class MENU_ADMIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MENU_ADMIN));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entregasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarEntregaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarEntregaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pERSONASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarTiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarTiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarTiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockToolStripMenuItem,
            this.entregasToolStripMenuItem,
            this.pERSONASToolStripMenuItem,
            this.tiposToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(790, 45);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarStockToolStripMenuItem});
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(94, 37);
            this.stockToolStripMenuItem.Text = "STOCK";
            // 
            // modificarStockToolStripMenuItem
            // 
            this.modificarStockToolStripMenuItem.Name = "modificarStockToolStripMenuItem";
            this.modificarStockToolStripMenuItem.Size = new System.Drawing.Size(180, 38);
            this.modificarStockToolStripMenuItem.Text = "Modificar";
            this.modificarStockToolStripMenuItem.Click += new System.EventHandler(this.modificarStockToolStripMenuItem_Click);
            // 
            // entregasToolStripMenuItem
            // 
            this.entregasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelarEntregaToolStripMenuItem,
            this.modificarEntregaToolStripMenuItem});
            this.entregasToolStripMenuItem.Name = "entregasToolStripMenuItem";
            this.entregasToolStripMenuItem.Size = new System.Drawing.Size(137, 37);
            this.entregasToolStripMenuItem.Text = "ENTREGAS";
            // 
            // cancelarEntregaToolStripMenuItem
            // 
            this.cancelarEntregaToolStripMenuItem.Name = "cancelarEntregaToolStripMenuItem";
            this.cancelarEntregaToolStripMenuItem.Size = new System.Drawing.Size(180, 38);
            this.cancelarEntregaToolStripMenuItem.Text = "Cancelar";
            this.cancelarEntregaToolStripMenuItem.Click += new System.EventHandler(this.cancelarEntregaToolStripMenuItem_Click);
            // 
            // modificarEntregaToolStripMenuItem
            // 
            this.modificarEntregaToolStripMenuItem.Name = "modificarEntregaToolStripMenuItem";
            this.modificarEntregaToolStripMenuItem.Size = new System.Drawing.Size(180, 38);
            this.modificarEntregaToolStripMenuItem.Text = "Modificar";
            this.modificarEntregaToolStripMenuItem.Click += new System.EventHandler(this.modificarEntregaToolStripMenuItem_Click);
            // 
            // pERSONASToolStripMenuItem
            // 
            this.pERSONASToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarToolStripMenuItem});
            this.pERSONASToolStripMenuItem.Name = "pERSONASToolStripMenuItem";
            this.pERSONASToolStripMenuItem.Size = new System.Drawing.Size(136, 37);
            this.pERSONASToolStripMenuItem.Text = "PERSONAS";
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(180, 38);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // tiposToolStripMenuItem
            // 
            this.tiposToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarTiposToolStripMenuItem,
            this.modificarTiposToolStripMenuItem,
            this.administrarTiposToolStripMenuItem});
            this.tiposToolStripMenuItem.Name = "tiposToolStripMenuItem";
            this.tiposToolStripMenuItem.Size = new System.Drawing.Size(86, 37);
            this.tiposToolStripMenuItem.Text = "TIPOS";
            // 
            // agregarTiposToolStripMenuItem
            // 
            this.agregarTiposToolStripMenuItem.Name = "agregarTiposToolStripMenuItem";
            this.agregarTiposToolStripMenuItem.Size = new System.Drawing.Size(208, 38);
            this.agregarTiposToolStripMenuItem.Text = "Agregar";
            this.agregarTiposToolStripMenuItem.Click += new System.EventHandler(this.agregarTiposToolStripMenuItem_Click);
            // 
            // modificarTiposToolStripMenuItem
            // 
            this.modificarTiposToolStripMenuItem.Name = "modificarTiposToolStripMenuItem";
            this.modificarTiposToolStripMenuItem.Size = new System.Drawing.Size(208, 38);
            this.modificarTiposToolStripMenuItem.Text = "Modificar";
            this.modificarTiposToolStripMenuItem.Click += new System.EventHandler(this.modificarTiposToolStripMenuItem_Click);
            // 
            // administrarTiposToolStripMenuItem
            // 
            this.administrarTiposToolStripMenuItem.Name = "administrarTiposToolStripMenuItem";
            this.administrarTiposToolStripMenuItem.Size = new System.Drawing.Size(208, 38);
            this.administrarTiposToolStripMenuItem.Text = "Administrar";
            this.administrarTiposToolStripMenuItem.Click += new System.EventHandler(this.administrarTiposToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(86, 37);
            this.salirToolStripMenuItem.Text = "SALIR";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // Menu_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(790, 568);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Administrador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Admin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem entregasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarEntregaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarEntregaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarTiposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarTiposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarTiposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pERSONASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
    }
}