using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CineConBD
{
    public partial class Sala : Form
    {
        private bool editar;
        private int idSeleccionado;

        public Sala()
        {
            InitializeComponent();
            CambiarEdicion(false);
        }

        private void Sala_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CambiarEdicion(bool activa)
        {
            cbSucursal.Enabled = activa;
            numNumeroSala.Enabled = activa;
            txtTipoSala.ReadOnly = !activa;
            numCantidadAsientos.Enabled = activa;
            btnGuardar.Enabled = activa;
        }

        private void LimpiarFormulario()
        {
            cbSucursal.SelectedIndex = -1;
            numNumeroSala.Value = 0;
            txtTipoSala.Clear();
            numCantidadAsientos.Value = 0;
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    CargarCombo(conexion, "SELECT IDSucursal, Nombre FROM dbo.Sucursal ORDER BY Nombre", cbSucursal, "IDSucursal", "Nombre");
                    SqlDataAdapter adaptador = new SqlDataAdapter(
                        "SELECT * FROM dbo.Sala ORDER BY IDSala", conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvSala.DataSource = tabla;
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
            if (dgvSala.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una fila.");
                return;
            }
            DataGridViewRow fila = dgvSala.CurrentRow;
            idSeleccionado = Convert.ToInt32(fila.Cells["IDSala"].Value);
            if (fila.Cells["IDSucursal"].Value == DBNull.Value) cbSucursal.SelectedIndex = -1;
            else cbSucursal.SelectedValue = fila.Cells["IDSucursal"].Value;
            numNumeroSala.Value = fila.Cells["NumeroSala"].Value == DBNull.Value ? 0 : Convert.ToDecimal(fila.Cells["NumeroSala"].Value);
            txtTipoSala.Text = Convert.ToString(fila.Cells["TipoSala"].Value);
            numCantidadAsientos.Value = fila.Cells["CantidadAsientos"].Value == DBNull.Value ? 0 : Convert.ToDecimal(fila.Cells["CantidadAsientos"].Value);
            editar = true;
            CambiarEdicion(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbSucursal.SelectedIndex < 0)
            {
                MessageBox.Show("Indica sucursal.");
                return;
            }
            if (numNumeroSala.Value <= 0)
            {
                MessageBox.Show("Indica número de sala.");
                return;
            }
            if (numCantidadAsientos.Value <= 0)
            {
                MessageBox.Show("Indica asientos.");
                return;
            }
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = conexion.CreateCommand())
                {
                    if (editar)
                        comando.CommandText = "UPDATE dbo.Sala SET IDSucursal=@IDSucursal, NumeroSala=@NumeroSala, TipoSala=@TipoSala, CantidadAsientos=@CantidadAsientos WHERE IDSala=@id";
                    else
                        comando.CommandText = "INSERT INTO dbo.Sala (IDSucursal, NumeroSala, TipoSala, CantidadAsientos) VALUES (@IDSucursal, @NumeroSala, @TipoSala, @CantidadAsientos)";
                    comando.Parameters.AddWithValue("@IDSucursal", cbSucursal.SelectedValue);
                    comando.Parameters.AddWithValue("@NumeroSala", Convert.ToInt32(numNumeroSala.Value));
                    comando.Parameters.AddWithValue("@TipoSala", string.IsNullOrWhiteSpace(txtTipoSala.Text) ? (object)DBNull.Value : txtTipoSala.Text.Trim());
                    comando.Parameters.AddWithValue("@CantidadAsientos", Convert.ToInt32(numCantidadAsientos.Value));
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
            if (dgvSala.CurrentRow == null)
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
                    "DELETE FROM dbo.Sala WHERE IDSala=@id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", dgvSala.CurrentRow.Cells["IDSala"].Value);
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
