using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CineConBD
{
    public partial class Funcion : Form
    {
        private bool editar;
        private int idSeleccionado;

        public Funcion()
        {
            InitializeComponent();
            CambiarEdicion(false);
        }

        private void Funcion_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CambiarEdicion(bool activa)
        {
            cbPelicula.Enabled = activa;
            cbSala.Enabled = activa;
            dtFecha.Enabled = activa;
            numHora.Enabled = activa;
            btnGuardar.Enabled = activa;
        }

        private void LimpiarFormulario()
        {
            cbPelicula.SelectedIndex = -1;
            cbSala.SelectedIndex = -1;
            dtFecha.Checked = false;
            numHora.Value = 0;
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    CargarCombo(conexion, "SELECT IDPelicula, NombrePelicula FROM dbo.Pelicula ORDER BY NombrePelicula", cbPelicula, "IDPelicula", "NombrePelicula");
                    CargarCombo(conexion, "SELECT IDSala, NumeroSala FROM dbo.Sala ORDER BY NumeroSala", cbSala, "IDSala", "NumeroSala");
                    SqlDataAdapter adaptador = new SqlDataAdapter(
                        "SELECT * FROM dbo.Funcion ORDER BY IDFuncion", conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvFuncion.DataSource = tabla;
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
            if (dgvFuncion.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una fila.");
                return;
            }
            DataGridViewRow fila = dgvFuncion.CurrentRow;
            idSeleccionado = Convert.ToInt32(fila.Cells["IDFuncion"].Value);
            if (fila.Cells["IDPelicula"].Value == DBNull.Value) cbPelicula.SelectedIndex = -1;
            else cbPelicula.SelectedValue = fila.Cells["IDPelicula"].Value;
            if (fila.Cells["IDSala"].Value == DBNull.Value) cbSala.SelectedIndex = -1;
            else cbSala.SelectedValue = fila.Cells["IDSala"].Value;
            dtFecha.Checked = fila.Cells["Fecha"].Value != DBNull.Value;
            if (dtFecha.Checked) dtFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);
            numHora.Value = fila.Cells["Hora"].Value == DBNull.Value ? 0 : Convert.ToDecimal(fila.Cells["Hora"].Value);
            editar = true;
            CambiarEdicion(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbPelicula.SelectedIndex < 0)
            {
                MessageBox.Show("Indica película.");
                return;
            }
            if (cbSala.SelectedIndex < 0)
            {
                MessageBox.Show("Indica sala.");
                return;
            }
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = conexion.CreateCommand())
                {
                    if (editar)
                        comando.CommandText = "UPDATE dbo.Funcion SET IDPelicula=@IDPelicula, IDSala=@IDSala, Fecha=@Fecha, Hora=@Hora WHERE IDFuncion=@id";
                    else
                        comando.CommandText = "INSERT INTO dbo.Funcion (IDPelicula, IDSala, Fecha, Hora) VALUES (@IDPelicula, @IDSala, @Fecha, @Hora)";
                    comando.Parameters.AddWithValue("@IDPelicula", cbPelicula.SelectedValue);
                    comando.Parameters.AddWithValue("@IDSala", cbSala.SelectedValue);
                    comando.Parameters.AddWithValue("@Fecha", dtFecha.Checked ? (object)dtFecha.Value.Date : DBNull.Value);
                    comando.Parameters.AddWithValue("@Hora", Convert.ToInt32(numHora.Value));
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
            if (dgvFuncion.CurrentRow == null)
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
                    "DELETE FROM dbo.Funcion WHERE IDFuncion=@id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", dgvFuncion.CurrentRow.Cells["IDFuncion"].Value);
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
