using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CineConBD
{
    public partial class Cliente : Form
    {
        private bool editar;
        private int idSeleccionado;

        public Cliente()
        {
            InitializeComponent();
            CambiarEdicion(false);
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CambiarEdicion(bool activa)
        {
            cbCiudad.Enabled = activa;
            txtNombre.ReadOnly = !activa;
            txtCelular.ReadOnly = !activa;
            txtCorreo.ReadOnly = !activa;
            btnGuardar.Enabled = activa;
        }

        private void LimpiarFormulario()
        {
            cbCiudad.SelectedIndex = -1;
            txtNombre.Clear();
            txtCelular.Clear();
            txtCorreo.Clear();
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    CargarCombo(conexion, "SELECT IDCiudad, NombreCiudad FROM dbo.Ciudad ORDER BY NombreCiudad", cbCiudad, "IDCiudad", "NombreCiudad");
                    SqlDataAdapter adaptador = new SqlDataAdapter(
                        "SELECT * FROM dbo.Cliente ORDER BY IDCliente", conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvCliente.DataSource = tabla;
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
            if (dgvCliente.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una fila.");
                return;
            }
            DataGridViewRow fila = dgvCliente.CurrentRow;
            idSeleccionado = Convert.ToInt32(fila.Cells["IDCliente"].Value);
            if (fila.Cells["IDCiudad"].Value == DBNull.Value) cbCiudad.SelectedIndex = -1;
            else cbCiudad.SelectedValue = fila.Cells["IDCiudad"].Value;
            txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            txtCelular.Text = Convert.ToString(fila.Cells["Celular"].Value);
            txtCorreo.Text = Convert.ToString(fila.Cells["Correo"].Value);
            editar = true;
            CambiarEdicion(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbCiudad.SelectedIndex < 0)
            {
                MessageBox.Show("Indica ciudad.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
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
                        comando.CommandText = "UPDATE dbo.Cliente SET IDCiudad=@IDCiudad, Nombre=@Nombre, Celular=@Celular, Correo=@Correo WHERE IDCliente=@id";
                    else
                        comando.CommandText = "INSERT INTO dbo.Cliente (IDCiudad, Nombre, Celular, Correo) VALUES (@IDCiudad, @Nombre, @Celular, @Correo)";
                    comando.Parameters.AddWithValue("@IDCiudad", cbCiudad.SelectedValue);
                    comando.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                    comando.Parameters.AddWithValue("@Celular", string.IsNullOrWhiteSpace(txtCelular.Text) ? (object)DBNull.Value : txtCelular.Text.Trim());
                    comando.Parameters.AddWithValue("@Correo", string.IsNullOrWhiteSpace(txtCorreo.Text) ? (object)DBNull.Value : txtCorreo.Text.Trim());
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
            if (dgvCliente.CurrentRow == null)
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
                    "DELETE FROM dbo.Cliente WHERE IDCliente=@id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", dgvCliente.CurrentRow.Cells["IDCliente"].Value);
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
