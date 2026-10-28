using System;
using System.Windows.Forms;

namespace CineConBD
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Abrir(Form ventana)
        {
            using (ventana)
                ventana.ShowDialog(this);
        }

        private void clasificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Clasificacion());
        }

        private void generoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Genero());
        }

        private void peliculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Pelicula());
        }

        private void sucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Sucursal());
        }

        private void salaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Sala());
        }

        private void tipoBoletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new TipoBoleto());
        }

        private void ciudadEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new CiudadEstado());
        }

        private void funcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Funcion());
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Cliente());
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Venta());
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
