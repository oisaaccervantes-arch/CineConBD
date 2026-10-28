using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CineConBD
{
    public partial class Genero : Form
    {
        private bool editar;
        private int idSeleccionado;

        public Genero()
        {
            InitializeComponent();
            CambiarEdicion(false);
        }

        private void Genero_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CambiarEdicion(bool activa)
        {
            txtNombreGenero.ReadOnly = !activa;
            txtDescripcionGenero.ReadOnly = !activa;
            btnGuardar.Enabled = activa;
        }

        private void LimpiarFormulario()
        {
            txtNombreGenero.Clear();
            txtDescripcionGenero.Clear();
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(
                        "SELECT * FROM dbo.Genero ORDER BY IDGenero", conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvGenero.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos: " + ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editar = false;
            LimpiarFormulario();
            CambiarEdicion(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvGenero.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una fila.");
                return;
            }
            DataGridViewRow fila = dgvGenero.CurrentRow;
            idSeleccionado = Convert.ToInt32(fila.Cells["IDGenero"].Value);
            txtNombreGenero.Text = Convert.ToString(fila.Cells["NombreGenero"].Value);
            txtDescripcionGenero.Text = Convert.ToString(fila.Cells["DescripcionGenero"].Value);
            editar = true;
            CambiarEdicion(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreGenero.Text))
            {
                MessageBox.Show("Indica nombre.");
                return;
            }
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = conexion.CreateCommand())
                {
                    if (editar)
                        comando.CommandText = "UPDATE dbo.Genero SET NombreGenero=@NombreGenero, DescripcionGenero=@DescripcionGenero WHERE IDGenero=@id";
                    else
                        comando.CommandText = "INSERT INTO dbo.Genero (NombreGenero, DescripcionGenero) VALUES (@NombreGenero, @DescripcionGenero)";
                    comando.Parameters.AddWithValue("@NombreGenero", txtNombreGenero.Text.Trim());
                    comando.Parameters.AddWithValue("@DescripcionGenero", string.IsNullOrWhiteSpace(txtDescripcionGenero.Text) ? (object)DBNull.Value : txtDescripcionGenero.Text.Trim());
                    if (editar) comando.Parameters.AddWithValue("@id", idSeleccionado);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                LimpiarFormulario();
                CambiarEdicion(false);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvGenero.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una fila.");
                return;
            }
            if (MessageBox.Show("¿Eliminar la fila seleccionada?", "Confirmar",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(
                    "DELETE FROM dbo.Genero WHERE IDGenero=@id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", dgvGenero.CurrentRow.Cells["IDGenero"].Value);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                LimpiarFormulario();
                CambiarEdicion(false);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar. Es posible que el registro esté en uso. " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            CambiarEdicion(false);
            CargarDatos();
        }
    }
}
