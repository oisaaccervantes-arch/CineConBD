namespace CineConBD
{
    partial class Genero
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.DataGridView dgvGenero;
        private System.Windows.Forms.Label lblNombreGenero;
        private System.Windows.Forms.TextBox txtNombreGenero;
        private System.Windows.Forms.Label lblDescripcionGenero;
        private System.Windows.Forms.TextBox txtDescripcionGenero;

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
            this.dgvGenero = new System.Windows.Forms.DataGridView();
            this.lblNombreGenero = new System.Windows.Forms.Label();
            this.txtNombreGenero = new System.Windows.Forms.TextBox();
            this.lblDescripcionGenero = new System.Windows.Forms.Label();
            this.txtDescripcionGenero = new System.Windows.Forms.TextBox();
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
            this.dgvGenero.AllowUserToAddRows = false;
            this.dgvGenero.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvGenero.Location = new System.Drawing.Point(12, 35);
            this.dgvGenero.Name = "dgvGenero";
            this.dgvGenero.ReadOnly = true;
            this.dgvGenero.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGenero.MultiSelect = false;
            this.dgvGenero.Size = new System.Drawing.Size(870, 195);
            this.lblNombreGenero.AutoSize = true;
            this.lblNombreGenero.Location = new System.Drawing.Point(30, 259);
            this.lblNombreGenero.Name = "lblNombreGenero";
            this.lblNombreGenero.Text = "Nombre";
            this.txtNombreGenero.Location = new System.Drawing.Point(180, 255);
            this.txtNombreGenero.Name = "txtNombreGenero";
            this.txtNombreGenero.Size = new System.Drawing.Size(250, 23);
            this.txtNombreGenero.MaxLength = 30;
            this.lblDescripcionGenero.AutoSize = true;
            this.lblDescripcionGenero.Location = new System.Drawing.Point(30, 297);
            this.lblDescripcionGenero.Name = "lblDescripcionGenero";
            this.lblDescripcionGenero.Text = "Descripción";
            this.txtDescripcionGenero.Location = new System.Drawing.Point(180, 293);
            this.txtDescripcionGenero.Name = "txtDescripcionGenero";
            this.txtDescripcionGenero.Size = new System.Drawing.Size(250, 23);
            this.txtDescripcionGenero.MaxLength = 200;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.lblNombreGenero);
            this.Controls.Add(this.txtNombreGenero);
            this.Controls.Add(this.lblDescripcionGenero);
            this.Controls.Add(this.txtDescripcionGenero);
            this.Controls.Add(this.dgvGenero);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Genero";
            this.Text = "Género";
            this.Load += new System.EventHandler(this.Genero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
