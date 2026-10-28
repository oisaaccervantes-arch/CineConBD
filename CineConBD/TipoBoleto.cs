using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CineConBD
{
    public partial class TipoBoleto : Form
    {
        private bool editar;
        private int idSeleccionado;

        public TipoBoleto()
        {
            InitializeComponent();
            CambiarEdicion(false);
        }

        private void TipoBoleto_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CambiarEdicion(bool activa)
        {
            txtClave.ReadOnly = !activa;
            txtDescripcion.ReadOnly = !activa;
            numPrecio.Enabled = activa;
            btnGuardar.Enabled = activa;
        }

        private void LimpiarFormulario()
        {
            txtClave.Clear();
            txtDescripcion.Clear();
            numPrecio.Value = 0;
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(
                        "SELECT * FROM dbo.TipoBoleto ORDER BY IDTipoBoleto", conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvTipoBoleto.DataSource = tabla;
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
            if (dgvTipoBoleto.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una fila.");
                return;
            }
            DataGridViewRow fila = dgvTipoBoleto.CurrentRow;
            idSeleccionado = Convert.ToInt32(fila.Cells["IDTipoBoleto"].Value);
            txtClave.Text = Convert.ToString(fila.Cells["Clave"].Value);
            txtDescripcion.Text = Convert.ToString(fila.Cells["Descripcion"].Value);
            numPrecio.Value = fila.Cells["Precio"].Value == DBNull.Value ? 0 : Convert.ToDecimal(fila.Cells["Precio"].Value);
            editar = true;
            CambiarEdicion(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = conexion.CreateCommand())
                {
                    if (editar)
                        comando.CommandText = "UPDATE dbo.TipoBoleto SET Clave=@Clave, Descripcion=@Descripcion, Precio=@Precio WHERE IDTipoBoleto=@id";
                    else
                        comando.CommandText = "INSERT INTO dbo.TipoBoleto (Clave, Descripcion, Precio) VALUES (@Clave, @Descripcion, @Precio)";
                    comando.Parameters.AddWithValue("@Clave", string.IsNullOrWhiteSpace(txtClave.Text) ? (object)DBNull.Value : txtClave.Text.Trim());
                    comando.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(txtDescripcion.Text) ? (object)DBNull.Value : txtDescripcion.Text.Trim());
                    comando.Parameters.AddWithValue("@Precio", numPrecio.Value);
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
            if (dgvTipoBoleto.CurrentRow == null)
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
                    "DELETE FROM dbo.TipoBoleto WHERE IDTipoBoleto=@id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", dgvTipoBoleto.CurrentRow.Cells["IDTipoBoleto"].Value);
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
