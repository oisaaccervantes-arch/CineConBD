using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CineConBD
{
    public partial class Clasificacion : Form
    {
        private bool editar;
        private int idSeleccionado;

        public Clasificacion()
        {
            InitializeComponent();
            CambiarEdicion(false);
        }

        private void Clasificacion_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CambiarEdicion(bool activa)
        {
            txtClave.ReadOnly = !activa;
            txtDescripcion.ReadOnly = !activa;
            btnGuardar.Enabled = activa;
        }

        private void LimpiarFormulario()
        {
            txtClave.Clear();
            txtDescripcion.Clear();
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(
                        "SELECT * FROM dbo.Clasificacion ORDER BY IDClasificacion", conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvClasificacion.DataSource = tabla;
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
            if (dgvClasificacion.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una fila.");
                return;
            }
            DataGridViewRow fila = dgvClasificacion.CurrentRow;
            idSeleccionado = Convert.ToInt32(fila.Cells["IDClasificacion"].Value);
            txtClave.Text = Convert.ToString(fila.Cells["Clave"].Value);
            txtDescripcion.Text = Convert.ToString(fila.Cells["Descripcion"].Value);
            editar = true;
            CambiarEdicion(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Indica clave.");
                return;
            }
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = conexion.CreateCommand())
                {
                    if (editar)
                        comando.CommandText = "UPDATE dbo.Clasificacion SET Clave=@Clave, Descripcion=@Descripcion WHERE IDClasificacion=@id";
                    else
                        comando.CommandText = "INSERT INTO dbo.Clasificacion (Clave, Descripcion) VALUES (@Clave, @Descripcion)";
                    comando.Parameters.AddWithValue("@Clave", txtClave.Text.Trim());
                    comando.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(txtDescripcion.Text) ? (object)DBNull.Value : txtDescripcion.Text.Trim());
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
            if (dgvClasificacion.CurrentRow == null)
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
                    "DELETE FROM dbo.Clasificacion WHERE IDClasificacion=@id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", dgvClasificacion.CurrentRow.Cells["IDClasificacion"].Value);
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
