using MySql.Data.MySqlClient;
using Restaurante_Sabor_Gourmet.Jaqueline.Clases;
using Restaurante_Sabor_Gourmet.Jaqueline.ConsultasSQL;
using Restaurante_Sabor_Gourmet.Jaqueline.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_Sabor_Gourmet.Jaqueline.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnInicioSesion_Click(object sender, EventArgs e)
        {

            // Validar campos vacíos
            if (ValidacionesLogin.CamposVacios(txtUsuario.Text, txtContrasena.Text))
            {
                MessageBox.Show("Debe ingresar usuario y contraseña");
                return;
            }

            //  Crear objeto de consultas SQL
            SQLUsuarios sql = new SQLUsuarios();

            try
            {
                // Validar usuario en base de datos
                bool loginCorrecto = sql.IniciarSesion(
                    txtUsuario.Text.Trim(),
                    txtContrasena.Text.Trim()
                );

                //  Verificar resultado
                if (loginCorrecto)
                {
                    // Abrir formulario principal
                    FrmPrincipal frm = new FrmPrincipal();
                    //frm.Show();

                    // Ocultar login
                    this.Hide();
                    frm.ShowDialog();     // Espera hasta que se cierre el principal
                    this.Show();          // Vuelve a mostrar el login

                    // Limpiar los campos
                    txtUsuario.Clear();
                    txtContrasena.Clear();

                    // Colocar el cursor en el usuario
                    txtUsuario.Focus();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                // Error de conexión o SQL
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }

}
