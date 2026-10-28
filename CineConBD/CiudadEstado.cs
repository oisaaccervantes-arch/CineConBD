using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CineConBD
{
    public partial class CiudadEstado : Form
    {
        private bool editarEstado;
        private bool editarCiudad;
        private int idEstado;
        private int idCiudad;

        public CiudadEstado()
        {
            InitializeComponent();
            CambiarEdicionEstado(false);
            CambiarEdicionCiudad(false);
        }

        private void CiudadEstado_Load(object sender, EventArgs e)
        {
            CargarEstados();
            CargarCiudades();
        }

        private void CargarEstados()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(
                        "SELECT * FROM dbo.Estado ORDER BY IDEstado", conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvEstado.DataSource = tabla;

                    adaptador = new SqlDataAdapter(
                        "SELECT IDEstado, NombreEstado FROM dbo.Estado ORDER BY NombreEstado", conexion);
                    tabla = new DataTable();
                    adaptador.Fill(tabla);
                    cbEstado.DataSource = tabla;
                    cbEstado.DisplayMember = "NombreEstado";
                    cbEstado.ValueMember = "IDEstado";
                    cbEstado.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los estados: " + ex.Message);
            }
        }

        private void CargarCiudades()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(
                        "SELECT * FROM dbo.Ciudad ORDER BY IDCiudad", conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvCiudad.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las ciudades: " + ex.Message);
            }
        }

        private void CambiarEdicionEstado(bool activa)
        {
            txtSiglaEstado.ReadOnly = !activa;
            numClaveEstado.Enabled = activa;
            txtNombreEstado.ReadOnly = !activa;
            btnGuardarEstado.Enabled = activa;
        }

        private void CambiarEdicionCiudad(bool activa)
        {
            cbEstado.Enabled = activa;
            txtSiglasCiudad.ReadOnly = !activa;
            numClaveCiudad.Enabled = activa;
            txtNombreCiudad.ReadOnly = !activa;
            btnGuardarCiudad.Enabled = activa;
        }

        private void LimpiarEstado()
        {
            txtSiglaEstado.Clear();
            numClaveEstado.Value = 0;
            txtNombreEstado.Clear();
        }

        private void LimpiarCiudad()
        {
            cbEstado.SelectedIndex = -1;
            txtSiglasCiudad.Clear();
            numClaveCiudad.Value = 0;
            txtNombreCiudad.Clear();
        }

        private void btnNuevoEstado_Click(object sender, EventArgs e)
        {
            editarEstado = false;
            LimpiarEstado();
            CambiarEdicionEstado(true);
        }

        private void btnEditarEstado_Click(object sender, EventArgs e)
        {
            if (dgvEstado.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un estado.");
                return;
            }
            DataGridViewRow fila = dgvEstado.CurrentRow;
            idEstado = Convert.ToInt32(fila.Cells["IDEstado"].Value);
            txtSiglaEstado.Text = Convert.ToString(fila.Cells["SiglaEstado"].Value);
            numClaveEstado.Value = fila.Cells["ClaveEstado"].Value == DBNull.Value ?
                0 : Convert.ToDecimal(fila.Cells["ClaveEstado"].Value);
            txtNombreEstado.Text = Convert.ToString(fila.Cells["NombreEstado"].Value);
            editarEstado = true;
            CambiarEdicionEstado(true);
        }

        private void btnGuardarEstado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSiglaEstado.Text))
            {
                MessageBox.Show("Indica la sigla del estado.");
                return;
            }
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = conexion.CreateCommand())
                {
                    if (editarEstado)
                        comando.CommandText = "UPDATE dbo.Estado SET SiglaEstado=@sigla, " +
                            "ClaveEstado=@clave, NombreEstado=@nombre WHERE IDEstado=@id";
                    else
                        comando.CommandText = "INSERT INTO dbo.Estado " +
                            "(SiglaEstado, ClaveEstado, NombreEstado) VALUES (@sigla, @clave, @nombre)";
                    comando.Parameters.AddWithValue("@sigla", txtSiglaEstado.Text.Trim());
                    comando.Parameters.AddWithValue("@clave", Convert.ToInt32(numClaveEstado.Value));
                    comando.Parameters.AddWithValue("@nombre", string.IsNullOrWhiteSpace(txtNombreEstado.Text) ?
                        (object)DBNull.Value : txtNombreEstado.Text.Trim());
                    if (editarEstado) comando.Parameters.AddWithValue("@id", idEstado);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                LimpiarEstado();
                CambiarEdicionEstado(false);
                CargarEstados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el estado: " + ex.Message);
            }
        }

        private void btnEliminarEstado_Click(object sender, EventArgs e)
        {
            if (dgvEstado.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un estado.");
                return;
            }
            if (MessageBox.Show("¿Eliminar el estado?", "Confirmar",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(
                    "DELETE FROM dbo.Estado WHERE IDEstado=@id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", dgvEstado.CurrentRow.Cells["IDEstado"].Value);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                LimpiarEstado();
                CambiarEdicionEstado(false);
                CargarEstados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el estado: " + ex.Message);
            }
        }

        private void btnActualizarEstado_Click(object sender, EventArgs e)
        {
            LimpiarEstado();
            CambiarEdicionEstado(false);
            CargarEstados();
        }

        private void btnNuevoCiudad_Click(object sender, EventArgs e)
        {
            editarCiudad = false;
            LimpiarCiudad();
            CambiarEdicionCiudad(true);
        }

        private void btnEditarCiudad_Click(object sender, EventArgs e)
        {
            if (dgvCiudad.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una ciudad.");
                return;
            }
            DataGridViewRow fila = dgvCiudad.CurrentRow;
            idCiudad = Convert.ToInt32(fila.Cells["IDCiudad"].Value);
            cbEstado.SelectedValue = fila.Cells["IDEstado"].Value;
            txtSiglasCiudad.Text = Convert.ToString(fila.Cells["SiglasCiudad"].Value);
            numClaveCiudad.Value = Convert.ToDecimal(fila.Cells["ClaveCiudad"].Value);
            txtNombreCiudad.Text = Convert.ToString(fila.Cells["NombreCiudad"].Value);
            editarCiudad = true;
            CambiarEdicionCiudad(true);
        }

        private void btnGuardarCiudad_Click(object sender, EventArgs e)
        {
            if (cbEstado.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtSiglasCiudad.Text) ||
                string.IsNullOrWhiteSpace(txtNombreCiudad.Text))
            {
                MessageBox.Show("Indica estado, siglas y nombre de la ciudad.");
                return;
            }
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = conexion.CreateCommand())
                {
                    if (editarCiudad)
                        comando.CommandText = "UPDATE dbo.Ciudad SET IDEstado=@estado, " +
                            "SiglasCiudad=@siglas, ClaveCiudad=@clave, NombreCiudad=@nombre " +
                            "WHERE IDCiudad=@id";
                    else
                        comando.CommandText = "INSERT INTO dbo.Ciudad " +
                            "(IDEstado, SiglasCiudad, ClaveCiudad, NombreCiudad) " +
                            "VALUES (@estado, @siglas, @clave, @nombre)";
                    comando.Parameters.AddWithValue("@estado", cbEstado.SelectedValue);
                    comando.Parameters.AddWithValue("@siglas", txtSiglasCiudad.Text.Trim());
                    comando.Parameters.AddWithValue("@clave", Convert.ToInt32(numClaveCiudad.Value));
                    comando.Parameters.AddWithValue("@nombre", txtNombreCiudad.Text.Trim());
                    if (editarCiudad) comando.Parameters.AddWithValue("@id", idCiudad);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                LimpiarCiudad();
                CambiarEdicionCiudad(false);
                CargarCiudades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la ciudad: " + ex.Message);
            }
        }

        private void btnEliminarCiudad_Click(object sender, EventArgs e)
        {
            if (dgvCiudad.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una ciudad.");
                return;
            }
            if (MessageBox.Show("¿Eliminar la ciudad?", "Confirmar",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(
                    "DELETE FROM dbo.Ciudad WHERE IDCiudad=@id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", dgvCiudad.CurrentRow.Cells["IDCiudad"].Value);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                LimpiarCiudad();
                CambiarEdicionCiudad(false);
                CargarCiudades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar la ciudad: " + ex.Message);
            }
        }

        private void btnActualizarCiudad_Click(object sender, EventArgs e)
        {
            LimpiarCiudad();
            CambiarEdicionCiudad(false);
            CargarEstados();
            CargarCiudades();
        }
    }
}
