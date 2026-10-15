using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CineConBD
{
    public partial class Pelicula : Form
    {
        private bool editar = false;
        
        public Pelicula()
        {
            InitializeComponent();
            ProbarConexión();
        }

        private void ProbarConexión()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    MessageBox.Show("Conexión exitosa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al probar la conexión: " + ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
