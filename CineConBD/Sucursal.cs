using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CineConBD
{
    public partial class Sucursal : Form
    {
        private bool editar;
        private int idSeleccionado;

        public Sucursal()
        {
            InitializeComponent();
            CambiarEdicion(false);
        }

        private void Sucursal_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CambiarEdicion(bool activa)
        {
            txtNombre.ReadOnly = !activa;
            txtDireccion.ReadOnly = !activa;
            cbCiudad.Enabled = activa;
            btnGuardar.Enabled = activa;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            cbCiudad.SelectedIndex = -1;
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    CargarCombo(conexion, "SELECT IDCiudad, NombreCiudad FROM dbo.Ciudad ORDER BY NombreCiudad", cbCiudad, "IDCiudad", "NombreCiudad");
                    SqlDataAdapter adaptador = new SqlDataAdapter(
                        "SELECT * FROM dbo.Sucursal ORDER BY IDSucursal", conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvSucursal.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos: " + ex.Message);
            }
        }

        private void CargarCombo(SqlConnection conexion, string consulta, ComboBox combo, string valor, string texto)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            combo.DataSource = tabla;
            combo.DisplayMember = texto;
            combo.ValueMember = valor;
            combo.SelectedIndex = -1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editar = false;
            LimpiarFormulario();
            CambiarEdicion(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSucursal.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una fila.");
                return;
            }
            DataGridViewRow fila = dgvSucursal.CurrentRow;
            idSeleccionado = Convert.ToInt32(fila.Cells["IDSucursal"].Value);
            txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            txtDireccion.Text = Convert.ToString(fila.Cells["Direccion"].Value);
            if (fila.Cells["IDCiudad"].Value == DBNull.Value) cbCiudad.SelectedIndex = -1;
            else cbCiudad.SelectedValue = fila.Cells["IDCiudad"].Value;
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
                        comando.CommandText = "UPDATE dbo.Sucursal SET Nombre=@Nombre, Direccion=@Direccion, IDCiudad=@IDCiudad WHERE IDSucursal=@id";
                    else
                        comando.CommandText = "INSERT INTO dbo.Sucursal (Nombre, Direccion, IDCiudad) VALUES (@Nombre, @Direccion, @IDCiudad)";
                    comando.Parameters.AddWithValue("@Nombre", string.IsNullOrWhiteSpace(txtNombre.Text) ? (object)DBNull.Value : txtNombre.Text.Trim());
                    comando.Parameters.AddWithValue("@Direccion", string.IsNullOrWhiteSpace(txtDireccion.Text) ? (object)DBNull.Value : txtDireccion.Text.Trim());
                    comando.Parameters.AddWithValue("@IDCiudad", cbCiudad.SelectedIndex < 0 ? (object)DBNull.Value : cbCiudad.SelectedValue);
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
            if (dgvSucursal.CurrentRow == null)
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
                    "DELETE FROM dbo.Sucursal WHERE IDSucursal=@id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", dgvSucursal.CurrentRow.Cells["IDSucursal"].Value);
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
