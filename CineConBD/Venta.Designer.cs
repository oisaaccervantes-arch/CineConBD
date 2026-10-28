namespace CineConBD
{
    partial class Venta
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.DataGridView dgvVenta;
        private System.Windows.Forms.Label lblIDCliente;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label lblIDFuncion;
        private System.Windows.Forms.ComboBox cbFuncion;
        private System.Windows.Forms.Label lblIDTipoBoleto;
        private System.Windows.Forms.ComboBox cbTipoBoleto;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.NumericUpDown numPrecio;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.dgvVenta = new System.Windows.Forms.DataGridView();
            this.lblIDCliente = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.lblIDFuncion = new System.Windows.Forms.Label();
            this.cbFuncion = new System.Windows.Forms.ComboBox();
            this.lblIDTipoBoleto = new System.Windows.Forms.Label();
            this.cbTipoBoleto = new System.Windows.Forms.ComboBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.SuspendLayout();
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.btnNuevo, this.btnGuardar, this.btnEditar, this.btnEliminar, this.btnActualizar });
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(900, 25);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            this.dgvVenta.AllowUserToAddRows = false;
            this.dgvVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvVenta.Location = new System.Drawing.Point(12, 35);
            this.dgvVenta.Name = "dgvVenta";
            this.dgvVenta.ReadOnly = true;
            this.dgvVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVenta.MultiSelect = false;
            this.dgvVenta.Size = new System.Drawing.Size(870, 195);
            this.lblIDCliente.AutoSize = true;
            this.lblIDCliente.Location = new System.Drawing.Point(30, 259);
            this.lblIDCliente.Name = "lblIDCliente";
            this.lblIDCliente.Text = "Cliente";
            this.cbCliente.Location = new System.Drawing.Point(180, 255);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(250, 23);
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lblIDFuncion.AutoSize = true;
            this.lblIDFuncion.Location = new System.Drawing.Point(30, 297);
            this.lblIDFuncion.Name = "lblIDFuncion";
            this.lblIDFuncion.Text = "Función";
            this.cbFuncion.Location = new System.Drawing.Point(180, 293);
            this.cbFuncion.Name = "cbFuncion";
            this.cbFuncion.Size = new System.Drawing.Size(250, 23);
            this.cbFuncion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lblIDTipoBoleto.AutoSize = true;
            this.lblIDTipoBoleto.Location = new System.Drawing.Point(30, 335);
            this.lblIDTipoBoleto.Name = "lblIDTipoBoleto";
            this.lblIDTipoBoleto.Text = "Tipo de boleto";
            this.cbTipoBoleto.Location = new System.Drawing.Point(180, 331);
            this.cbTipoBoleto.Name = "cbTipoBoleto";
            this.cbTipoBoleto.Size = new System.Drawing.Size(250, 23);
            this.cbTipoBoleto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(30, 373);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Text = "Precio";
            this.numPrecio.Location = new System.Drawing.Point(180, 369);
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new System.Drawing.Size(250, 23);
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Maximum = 1000000;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.lblIDCliente);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.lblIDFuncion);
            this.Controls.Add(this.cbFuncion);
            this.Controls.Add(this.lblIDTipoBoleto);
            this.Controls.Add(this.cbTipoBoleto);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.numPrecio);
            this.Controls.Add(this.dgvVenta);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Venta";
            this.Text = "Venta";
            this.Load += new System.EventHandler(this.Venta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
