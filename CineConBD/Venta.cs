using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CineConBD
{
    public partial class Venta : Form
    {
        private bool editar;
        private int idSeleccionado;

        public Venta()
        {
            InitializeComponent();
            CambiarEdicion(false);
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CambiarEdicion(bool activa)
        {
            cbCliente.Enabled = activa;
            cbFuncion.Enabled = activa;
            cbTipoBoleto.Enabled = activa;
            numPrecio.Enabled = activa;
            btnGuardar.Enabled = activa;
        }

        private void LimpiarFormulario()
        {
            cbCliente.SelectedIndex = -1;
            cbFuncion.SelectedIndex = -1;
            cbTipoBoleto.SelectedIndex = -1;
            numPrecio.Value = 0;
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    CargarCombo(conexion, "SELECT IDCliente, Nombre FROM dbo.Cliente ORDER BY Nombre", cbCliente, "IDCliente", "Nombre");
                    CargarCombo(conexion, "SELECT IDFuncion FROM dbo.Funcion ORDER BY IDFuncion", cbFuncion, "IDFuncion", "IDFuncion");
                    CargarCombo(conexion, "SELECT IDTipoBoleto, Clave FROM dbo.TipoBoleto ORDER BY Clave", cbTipoBoleto, "IDTipoBoleto", "Clave");
                    SqlDataAdapter adaptador = new SqlDataAdapter(
                        "SELECT * FROM dbo.Venta ORDER BY IDVenta", conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvVenta.DataSource = tabla;
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
            if (dgvVenta.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una fila.");
                return;
            }
            DataGridViewRow fila = dgvVenta.CurrentRow;
            idSeleccionado = Convert.ToInt32(fila.Cells["IDVenta"].Value);
            if (fila.Cells["IDCliente"].Value == DBNull.Value) cbCliente.SelectedIndex = -1;
            else cbCliente.SelectedValue = fila.Cells["IDCliente"].Value;
            if (fila.Cells["IDFuncion"].Value == DBNull.Value) cbFuncion.SelectedIndex = -1;
            else cbFuncion.SelectedValue = fila.Cells["IDFuncion"].Value;
            if (fila.Cells["IDTipoBoleto"].Value == DBNull.Value) cbTipoBoleto.SelectedIndex = -1;
            else cbTipoBoleto.SelectedValue = fila.Cells["IDTipoBoleto"].Value;
            numPrecio.Value = fila.Cells["Precio"].Value == DBNull.Value ? 0 : Convert.ToDecimal(fila.Cells["Precio"].Value);
            editar = true;
            CambiarEdicion(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbFuncion.SelectedIndex < 0)
            {
                MessageBox.Show("Indica función.");
                return;
            }
            if (cbTipoBoleto.SelectedIndex < 0)
            {
                MessageBox.Show("Indica tipo de boleto.");
                return;
            }
            if (numPrecio.Value <= 0)
            {
                MessageBox.Show("Indica precio.");
                return;
            }
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = conexion.CreateCommand())
                {
                    if (editar)
                        comando.CommandText = "UPDATE dbo.Venta SET IDCliente=@IDCliente, IDFuncion=@IDFuncion, IDTipoBoleto=@IDTipoBoleto, Precio=@Precio WHERE IDVenta=@id";
                    else
                        comando.CommandText = "INSERT INTO dbo.Venta (IDCliente, IDFuncion, IDTipoBoleto, Precio) VALUES (@IDCliente, @IDFuncion, @IDTipoBoleto, @Precio)";
                    comando.Parameters.AddWithValue("@IDCliente", cbCliente.SelectedIndex < 0 ? (object)DBNull.Value : cbCliente.SelectedValue);
                    comando.Parameters.AddWithValue("@IDFuncion", cbFuncion.SelectedValue);
                    comando.Parameters.AddWithValue("@IDTipoBoleto", cbTipoBoleto.SelectedValue);
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
            if (dgvVenta.CurrentRow == null)
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
                    "DELETE FROM dbo.Venta WHERE IDVenta=@id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", dgvVenta.CurrentRow.Cells["IDVenta"].Value);
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
