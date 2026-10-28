namespace CineConBD
{
    partial class Sala
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.DataGridView dgvSala;
        private System.Windows.Forms.Label lblIDSucursal;
        private System.Windows.Forms.ComboBox cbSucursal;
        private System.Windows.Forms.Label lblNumeroSala;
        private System.Windows.Forms.NumericUpDown numNumeroSala;
        private System.Windows.Forms.Label lblTipoSala;
        private System.Windows.Forms.TextBox txtTipoSala;
        private System.Windows.Forms.Label lblCantidadAsientos;
        private System.Windows.Forms.NumericUpDown numCantidadAsientos;

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
            this.dgvSala = new System.Windows.Forms.DataGridView();
            this.lblIDSucursal = new System.Windows.Forms.Label();
            this.cbSucursal = new System.Windows.Forms.ComboBox();
            this.lblNumeroSala = new System.Windows.Forms.Label();
            this.numNumeroSala = new System.Windows.Forms.NumericUpDown();
            this.lblTipoSala = new System.Windows.Forms.Label();
            this.txtTipoSala = new System.Windows.Forms.TextBox();
            this.lblCantidadAsientos = new System.Windows.Forms.Label();
            this.numCantidadAsientos = new System.Windows.Forms.NumericUpDown();
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
            this.dgvSala.AllowUserToAddRows = false;
            this.dgvSala.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvSala.Location = new System.Drawing.Point(12, 35);
            this.dgvSala.Name = "dgvSala";
            this.dgvSala.ReadOnly = true;
            this.dgvSala.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSala.MultiSelect = false;
            this.dgvSala.Size = new System.Drawing.Size(870, 195);
            this.lblIDSucursal.AutoSize = true;
            this.lblIDSucursal.Location = new System.Drawing.Point(30, 259);
            this.lblIDSucursal.Name = "lblIDSucursal";
            this.lblIDSucursal.Text = "Sucursal";
            this.cbSucursal.Location = new System.Drawing.Point(180, 255);
            this.cbSucursal.Name = "cbSucursal";
            this.cbSucursal.Size = new System.Drawing.Size(250, 23);
            this.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lblNumeroSala.AutoSize = true;
            this.lblNumeroSala.Location = new System.Drawing.Point(30, 297);
            this.lblNumeroSala.Name = "lblNumeroSala";
            this.lblNumeroSala.Text = "Número de sala";
            this.numNumeroSala.Location = new System.Drawing.Point(180, 293);
            this.numNumeroSala.Name = "numNumeroSala";
            this.numNumeroSala.Size = new System.Drawing.Size(250, 23);
            this.numNumeroSala.Maximum = 2147483647;
            this.lblTipoSala.AutoSize = true;
            this.lblTipoSala.Location = new System.Drawing.Point(30, 335);
            this.lblTipoSala.Name = "lblTipoSala";
            this.lblTipoSala.Text = "Tipo de sala";
            this.txtTipoSala.Location = new System.Drawing.Point(180, 331);
            this.txtTipoSala.Name = "txtTipoSala";
            this.txtTipoSala.Size = new System.Drawing.Size(250, 23);
            this.txtTipoSala.MaxLength = 15;
            this.lblCantidadAsientos.AutoSize = true;
            this.lblCantidadAsientos.Location = new System.Drawing.Point(30, 373);
            this.lblCantidadAsientos.Name = "lblCantidadAsientos";
            this.lblCantidadAsientos.Text = "Asientos";
            this.numCantidadAsientos.Location = new System.Drawing.Point(180, 369);
            this.numCantidadAsientos.Name = "numCantidadAsientos";
            this.numCantidadAsientos.Size = new System.Drawing.Size(250, 23);
            this.numCantidadAsientos.Maximum = 2147483647;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.lblIDSucursal);
            this.Controls.Add(this.cbSucursal);
            this.Controls.Add(this.lblNumeroSala);
            this.Controls.Add(this.numNumeroSala);
            this.Controls.Add(this.lblTipoSala);
            this.Controls.Add(this.txtTipoSala);
            this.Controls.Add(this.lblCantidadAsientos);
            this.Controls.Add(this.numCantidadAsientos);
            this.Controls.Add(this.dgvSala);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Sala";
            this.Text = "Sala";
            this.Load += new System.EventHandler(this.Sala_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
