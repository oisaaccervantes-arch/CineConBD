namespace CineConBD
{
    partial class Principal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pantallasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clasificacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peliculaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sucursalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoBoletoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciudadEstadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Label lblTitulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pantallasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clasificacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peliculaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucursalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoBoletoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciudadEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.pantallasToolStripMenuItem, this.salirToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.pantallasToolStripMenuItem.Text = "Pantallas";
            this.pantallasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.clasificacionToolStripMenuItem, this.generoToolStripMenuItem,
                this.peliculaToolStripMenuItem, this.sucursalToolStripMenuItem,
                this.salaToolStripMenuItem, this.tipoBoletoToolStripMenuItem,
                this.ciudadEstadoToolStripMenuItem, this.funcionToolStripMenuItem,
                this.clienteToolStripMenuItem, this.ventaToolStripMenuItem });
            this.clasificacionToolStripMenuItem.Text = "Clasificación";
            this.clasificacionToolStripMenuItem.Click += new System.EventHandler(this.clasificacionToolStripMenuItem_Click);
            this.generoToolStripMenuItem.Text = "Género";
            this.generoToolStripMenuItem.Click += new System.EventHandler(this.generoToolStripMenuItem_Click);
            this.peliculaToolStripMenuItem.Text = "Película";
            this.peliculaToolStripMenuItem.Click += new System.EventHandler(this.peliculaToolStripMenuItem_Click);
            this.sucursalToolStripMenuItem.Text = "Sucursal";
            this.sucursalToolStripMenuItem.Click += new System.EventHandler(this.sucursalToolStripMenuItem_Click);
            this.salaToolStripMenuItem.Text = "Sala";
            this.salaToolStripMenuItem.Click += new System.EventHandler(this.salaToolStripMenuItem_Click);
            this.tipoBoletoToolStripMenuItem.Text = "Tipo Boleto";
            this.tipoBoletoToolStripMenuItem.Click += new System.EventHandler(this.tipoBoletoToolStripMenuItem_Click);
            this.ciudadEstadoToolStripMenuItem.Text = "Ciudad y Estado";
            this.ciudadEstadoToolStripMenuItem.Click += new System.EventHandler(this.ciudadEstadoToolStripMenuItem_Click);
            this.funcionToolStripMenuItem.Text = "Función";
            this.funcionToolStripMenuItem.Click += new System.EventHandler(this.funcionToolStripMenuItem_Click);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            this.ventaToolStripMenuItem.Text = "Venta";
            this.ventaToolStripMenuItem.Click += new System.EventHandler(this.ventaToolStripMenuItem_Click);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(40, 70);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Selecciona una pantalla en el menú.";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Cine";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
