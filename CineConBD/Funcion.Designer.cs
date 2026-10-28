namespace CineConBD
{
    partial class Funcion
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.DataGridView dgvFuncion;
        private System.Windows.Forms.Label lblIDPelicula;
        private System.Windows.Forms.ComboBox cbPelicula;
        private System.Windows.Forms.Label lblIDSala;
        private System.Windows.Forms.ComboBox cbSala;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.NumericUpDown numHora;

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
            this.dgvFuncion = new System.Windows.Forms.DataGridView();
            this.lblIDPelicula = new System.Windows.Forms.Label();
            this.cbPelicula = new System.Windows.Forms.ComboBox();
            this.lblIDSala = new System.Windows.Forms.Label();
            this.cbSala = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.numHora = new System.Windows.Forms.NumericUpDown();
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
            this.dgvFuncion.AllowUserToAddRows = false;
            this.dgvFuncion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvFuncion.Location = new System.Drawing.Point(12, 35);
            this.dgvFuncion.Name = "dgvFuncion";
            this.dgvFuncion.ReadOnly = true;
            this.dgvFuncion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFuncion.MultiSelect = false;
            this.dgvFuncion.Size = new System.Drawing.Size(870, 195);
            this.lblIDPelicula.AutoSize = true;
            this.lblIDPelicula.Location = new System.Drawing.Point(30, 259);
            this.lblIDPelicula.Name = "lblIDPelicula";
            this.lblIDPelicula.Text = "Película";
            this.cbPelicula.Location = new System.Drawing.Point(180, 255);
            this.cbPelicula.Name = "cbPelicula";
            this.cbPelicula.Size = new System.Drawing.Size(250, 23);
            this.cbPelicula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lblIDSala.AutoSize = true;
            this.lblIDSala.Location = new System.Drawing.Point(30, 297);
            this.lblIDSala.Name = "lblIDSala";
            this.lblIDSala.Text = "Sala";
            this.cbSala.Location = new System.Drawing.Point(180, 293);
            this.cbSala.Name = "cbSala";
            this.cbSala.Size = new System.Drawing.Size(250, 23);
            this.cbSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(30, 335);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Text = "Fecha";
            this.dtFecha.Location = new System.Drawing.Point(180, 331);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(250, 23);
            this.dtFecha.ShowCheckBox = true;
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(30, 373);
            this.lblHora.Name = "lblHora";
            this.lblHora.Text = "Hora (HHMM)";
            this.numHora.Location = new System.Drawing.Point(180, 369);
            this.numHora.Name = "numHora";
            this.numHora.Size = new System.Drawing.Size(250, 23);
            this.numHora.Maximum = 2359;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.lblIDPelicula);
            this.Controls.Add(this.cbPelicula);
            this.Controls.Add(this.lblIDSala);
            this.Controls.Add(this.cbSala);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.numHora);
            this.Controls.Add(this.dgvFuncion);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Funcion";
            this.Text = "Función";
            this.Load += new System.EventHandler(this.Funcion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
