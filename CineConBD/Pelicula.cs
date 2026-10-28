using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CineConBD
{
    public partial class Pelicula : Form
    {
        private bool editar;
        private int idPelicula;

        public Pelicula()
        {
            InitializeComponent();
            cbGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClasificacion.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPelicula.MaxLength = 50;
            numDuracion.Maximum = int.MaxValue;
            CambiarEdicion(false);
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnActualizar.Click += btnActualizar_Click;
            CargarDatos();
        }

        private void CambiarEdicion(bool activa)
        {
            txtPelicula.ReadOnly = !activa;
            numDuracion.Enabled = activa;
            cbGenero.Enabled = activa;
            cbClasificacion.Enabled = activa;
            btnGuardar.Enabled = activa;
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    CargarCombo(conexion, "SELECT IDGenero, NombreGenero FROM dbo.Genero ORDER BY NombreGenero",
                        cbGenero, "IDGenero", "NombreGenero");
                    CargarCombo(conexion, "SELECT IDClasificacion, Clave FROM dbo.Clasificacion ORDER BY Clave",
                        cbClasificacion, "IDClasificacion", "Clave");

                    string consulta = "SELECT p.IDPelicula, p.NombrePelicula, p.Duracion, " +
                        "p.IDGenero, p.IDClasificacion, g.NombreGenero AS Genero, " +
                        "c.Clave AS Clasificacion FROM dbo.Pelicula p " +
                        "INNER JOIN dbo.Genero g ON p.IDGenero = g.IDGenero " +
                        "INNER JOIN dbo.Clasificacion c ON p.IDClasificacion = c.IDClasificacion " +
                        "ORDER BY p.IDPelicula";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvPeliculas.DataSource = tabla;
                    dgvPeliculas.Columns["IDGenero"].Visible = false;
                    dgvPeliculas.Columns["IDClasificacion"].Visible = false;
                    dgvPeliculas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las películas: " + ex.Message);
            }
        }

        private void CargarCombo(SqlConnection conexion, string consulta, ComboBox combo,
            string valor, string texto)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            combo.DataSource = tabla;
            combo.DisplayMember = texto;
            combo.ValueMember = valor;
            combo.SelectedIndex = -1;
        }

        private void btnNuevo_click(object sender, EventArgs e)
        {
            editar = false;
            LimpiarFormulario();
            CambiarEdicion(true);
            txtPelicula.Focus();
        }

        private void LimpiarFormulario()
        {
            txtPelicula.Clear();
            numDuracion.Value = 0;
            cbClasificacion.SelectedIndex = -1;
            cbGenero.SelectedIndex = -1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPeliculas.CurrentRow == null || dgvPeliculas.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Selecciona una película.");
                return;
            }
            DataGridViewRow fila = dgvPeliculas.CurrentRow;
            idPelicula = Convert.ToInt32(fila.Cells["IDPelicula"].Value);
            txtPelicula.Text = Convert.ToString(fila.Cells["NombrePelicula"].Value);
            numDuracion.Value = Convert.ToDecimal(fila.Cells["Duracion"].Value);
            cbGenero.SelectedValue = fila.Cells["IDGenero"].Value;
            cbClasificacion.SelectedValue = fila.Cells["IDClasificacion"].Value;
            editar = true;
            CambiarEdicion(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPelicula.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                txtPelicula.Focus();
                return;
            }
            if (numDuracion.Value <= 0 || cbGenero.SelectedIndex < 0 || cbClasificacion.SelectedIndex < 0)
            {
                MessageBox.Show("Indica duración, género y clasificación.");
                return;
            }
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = conexion.CreateCommand())
                {
                    if (editar)
                        comando.CommandText = "UPDATE dbo.Pelicula SET NombrePelicula=@nombre, " +
                            "Duracion=@duracion, IDGenero=@genero, IDClasificacion=@clasificacion " +
                            "WHERE IDPelicula=@id";
                    else
                        comando.CommandText = "INSERT INTO dbo.Pelicula " +
                            "(NombrePelicula, Duracion, IDGenero, IDClasificacion) " +
                            "VALUES (@nombre, @duracion, @genero, @clasificacion)";
                    comando.Parameters.AddWithValue("@nombre", txtPelicula.Text.Trim());
                    comando.Parameters.AddWithValue("@duracion", Convert.ToInt32(numDuracion.Value));
                    comando.Parameters.AddWithValue("@genero", cbGenero.SelectedValue);
                    comando.Parameters.AddWithValue("@clasificacion", cbClasificacion.SelectedValue);
                    if (editar)
                        comando.Parameters.AddWithValue("@id", idPelicula);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                LimpiarFormulario();
                CambiarEdicion(false);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la película: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPeliculas.CurrentRow == null || dgvPeliculas.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Selecciona una película.");
                return;
            }
            if (MessageBox.Show("¿Eliminar la película seleccionada?", "Confirmar",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(
                    "DELETE FROM dbo.Pelicula WHERE IDPelicula=@id", conexion))
                {
                    comando.Parameters.AddWithValue("@id",
                        dgvPeliculas.CurrentRow.Cells["IDPelicula"].Value);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                LimpiarFormulario();
                CambiarEdicion(false);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar. Puede que la película esté en uso. " + ex.Message);
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
