using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
using Restaurante_Sabor_Gourmet.Jaqueline.ConsultasSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_Sabor_Gourmet.Haydee
{
    public partial class frmUsuarios : Form
    {
        // ── Estado interno ────────────────────────────────────────────────
        private int _idSeleccionado = 0;
        private bool _modoEdicion = false;

        // ── DAO ───────────────────────────────────────────────────────────
        private readonly SQLUsuarios _sql = new SQLUsuarios();

        public frmUsuarios()
        {
            InitializeComponent();
        }

        // ══════════════════════════════════════════════════════════════════
        //  CARGA
        // ══════════════════════════════════════════════════════════════════
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            // Mostrar usuario en sesión en la barra superior
            lblUsuarioSesion.Text = Sesion.NombreUsuario;
            lblRolSesion.Text = Sesion.NombreRol;

            ConfigurarGrid();
            CargarRoles();
            CargarUsuarios();
            ModoCrear();
        }

        // ══════════════════════════════════════════════════════════════════
        //  CONFIGURAR COLUMNAS DEL GRID
        // ══════════════════════════════════════════════════════════════════
        private void ConfigurarGrid()
        {
            dgvUsuarios.Columns.Clear();

            dgvUsuarios.Columns.Add(CrearTexto("colNombre", "Nombre", "Nombre", 160));
            dgvUsuarios.Columns.Add(CrearTexto("colUsuario", "Usuario", "Usuario", 120));
            dgvUsuarios.Columns.Add(CrearTexto("colTelefono", "Teléfono", "Teléfono", 120));
            dgvUsuarios.Columns.Add(CrearTexto("colRol", "Rol", "Rol", 130));
            dgvUsuarios.Columns.Add(CrearTexto("colEstado", "Estado", "Estado", 90));

            // Botón Editar — azul
            dgvUsuarios.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colEditar",
                HeaderText = "✏ Editar",
                Text = "✏ Editar",
                UseColumnTextForButtonValue = true,
                Width = 90,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(37, 99, 235),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Botón Baja — rojo
            dgvUsuarios.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colBaja",
                HeaderText = "✖ Baja",
                Text = "✖ Baja",
                UseColumnTextForButtonValue = true,
                Width = 90,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(239, 68, 68),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
        }

        private DataGridViewTextBoxColumn CrearTexto(
            string name, string header, string dataProperty, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = dataProperty,
                Width = width
            };
        }

        // ══════════════════════════════════════════════════════════════════
        //  CARGAR ROLES EN COMBOBOX
        // ══════════════════════════════════════════════════════════════════
        private void CargarRoles()
        {
            try
            {
                cmbRol.Items.Clear();
                DataTable dt = _sql.ObtenerRoles();
                foreach (DataRow row in dt.Rows)
                {
                    cmbRol.Items.Add(new ComboItem
                    {
                        Id = Convert.ToInt32(row["id_rol"]),
                        Texto = row["nombre_rol"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  CARGAR USUARIOS EN GRID
        // ══════════════════════════════════════════════════════════════════
        private void CargarUsuarios(string filtro = "")
        {
            try
            {
                dgvUsuarios.DataSource = _sql.MostrarTodo(filtro);

                if (dgvUsuarios.Columns["id_usuario"] != null)
                    dgvUsuarios.Columns["id_usuario"].Visible = false;

                ColorearEstado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Pinta verde Activo / rojo Inactivo en la columna Estado
        private void ColorearEstado()
        {
            foreach (DataGridViewRow row in dgvUsuarios.Rows)
            {
                string estado = row.Cells["colEstado"].Value?.ToString();
                row.Cells["colEstado"].Style.ForeColor = estado == "Activo"
                    ? Color.FromArgb(34, 197, 94)
                    : Color.FromArgb(239, 68, 68);
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  BÚSQUEDA EN TIEMPO REAL
        // ══════════════════════════════════════════════════════════════════
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarUsuarios(txtBuscar.Text.Trim());
        }

        // ══════════════════════════════════════════════════════════════════
        //  CLICK EN CELDAS DEL GRID
        // ══════════════════════════════════════════════════════════════════
        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idUsuario = Convert.ToInt32(
                ((DataTable)dgvUsuarios.DataSource).Rows[e.RowIndex]["id_usuario"]);

            string col = dgvUsuarios.Columns[e.ColumnIndex].Name;

            if (col == "colEditar")
                CargarParaEditar(idUsuario);
            else if (col == "colBaja")
                Desactivar(idUsuario);
        }

        // ══════════════════════════════════════════════════════════════════
        //  CARGAR DATOS PARA EDITAR
        // ══════════════════════════════════════════════════════════════════
        private void CargarParaEditar(int idUsuario)
        {
            try
            {
                Usuario u = _sql.ObtenerPorId(idUsuario);
                if (u == null) return;

                _idSeleccionado = u.IdUsuario;
                _modoEdicion = true;

                txtNombre.Text = u.Nombre;
                txtUsername.Text = u.Username;
                txtTelefono.Text = u.Telefono;
                txtPassword.Text = "";   // No se precarga por seguridad

                foreach (ComboItem item in cmbRol.Items)
                {
                    if (item.Id == u.IdRol)
                    {
                        cmbRol.SelectedItem = item;
                        break;
                    }
                }

                lblTituloAccion.Text = "Editando usuario";
                btnGuardar.Text = "💾 Actualizar";
                btnCrearUsuario.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  BOTÓN NUEVO USUARIO
        // ══════════════════════════════════════════════════════════════════
        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            ModoCrear();
        }

        private void ModoCrear()
        {
            _idSeleccionado = 0;
            _modoEdicion = false;
            txtNombre.Text = "";
            txtUsername.Text = "";
            txtTelefono.Text = "";
            txtPassword.Text = "";
            cmbRol.SelectedIndex = -1;
            lblTituloAccion.Text = "Nuevo usuario";
            btnGuardar.Text = "💾 Guardar";
            btnCrearUsuario.Enabled = true;
            txtNombre.Focus();
        }

        // ══════════════════════════════════════════════════════════════════
        //  BOTÓN GUARDAR
        // ══════════════════════════════════════════════════════════════════
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones obligatorias
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                cmbRol.SelectedIndex < 0)
            {
                MessageBox.Show("Nombre, usuario y rol son obligatorios.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_modoEdicion && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingresa una contraseña para el nuevo usuario.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener mínimo 6 caracteres.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_modoEdicion)
                Actualizar();
            else
                Crear();
        }

        // ── Crear ─────────────────────────────────────────────────────────
        private void Crear()
        {
            try
            {
                if (_sql.UsernameExiste(txtUsername.Text.Trim()))
                {
                    MessageBox.Show("El nombre de usuario ya está en uso. Elige otro.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                Usuario u = new Usuario
                {
                    Nombre = txtNombre.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Contrasena = txtPassword.Text.Trim(),   // El DAO aplica el hash
                    Telefono = txtTelefono.Text.Trim(),
                    IdRol = ((ComboItem)cmbRol.SelectedItem).Id
                };

                if (_sql.Guardar(u))
                {
                    MessageBox.Show("Usuario creado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios(txtBuscar.Text.Trim());
                    ModoCrear();
                }
                else
                    MessageBox.Show("No se pudo crear el usuario.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Actualizar ────────────────────────────────────────────────────
        private void Actualizar()
        {
            try
            {
                if (_sql.UsernameExiste(txtUsername.Text.Trim(), _idSeleccionado))
                {
                    MessageBox.Show("El nombre de usuario ya está en uso. Elige otro.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                bool cambiaPassword = !string.IsNullOrWhiteSpace(txtPassword.Text);

                Usuario u = new Usuario
                {
                    IdUsuario = _idSeleccionado,
                    Nombre = txtNombre.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    IdRol = ((ComboItem)cmbRol.SelectedItem).Id,
                    Contrasena = cambiaPassword ? txtPassword.Text.Trim() : null
                };

                bool ok = cambiaPassword
                    ? _sql.ActualizarConClave(u)
                    : _sql.Actualizar(u);

                if (ok)
                {
                    MessageBox.Show("Usuario actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios(txtBuscar.Text.Trim());
                    ModoCrear();
                }
                else
                    MessageBox.Show("No se pudo actualizar el usuario.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Desactivar ────────────────────────────────────────────────────
        private void Desactivar(int idUsuario)
        {
            if (idUsuario == Sesion.IdUsuario)
            {
                MessageBox.Show("No puedes desactivar tu propia cuenta mientras estás en sesión.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Desactivar este usuario? No podrá iniciar sesión.",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                if (_sql.Desactivar(idUsuario))
                {
                    MessageBox.Show("Usuario desactivado.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios(txtBuscar.Text.Trim());
                }
                else
                    MessageBox.Show("No se pudo desactivar el usuario.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // ══════════════════════════════════════════════════════════════════════
    //  COMBO ITEM — para ComboBox con ID interno
    // ══════════════════════════════════════════════════════════════════════
    internal class ComboItem
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public override string ToString() => Texto;
    }
}
