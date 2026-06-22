using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
namespace Restaurante_Sabor_Gourmet.Jaqueline.Clases
{
    internal class PermisosUsuario
    {
        //Metodo que recibe como parametro los botones del formulario principal
        public void ConfigurarBotones(

            Guna2Button btnMesas,
            Guna2Button btnCocina,
            Guna2Button btnMenu,
            Guna2Button btnUsuarios,
            Guna2Button btnReportes,
            Guna2Button btnInventario,
            Guna2Button btnCaja,
            Guna2Button btnReservaciones,
            Guna2Button btnDashboard)
 
        {
            // Ocultar todos los botones
            btnMesas.Visible = false;
            btnCocina.Visible = false;
            btnMenu.Visible = false;
            btnUsuarios.Visible = false;
            btnReportes.Visible = false;
            btnInventario.Visible = false;
            btnCaja.Visible = false;
            btnReservaciones.Visible = false;
            btnDashboard.Visible = false;

            switch (Sesion.IdRol) // Los botones se habilitaran segun el rol del usuario que inice sesion
            {
                case 1: // Administrador

                    btnMesas.Visible = true;
                    btnCocina.Visible = true;
                    btnMenu.Visible = true;
                    btnUsuarios.Visible = true;
                    btnReportes.Visible = true;
                    btnInventario.Visible = true;
                    btnCaja.Visible = true;
                    btnReservaciones.Visible = true;
                    btnDashboard.Visible = true;

                    break;

                case 2: // Cajero

                    btnCaja.Visible = true;

                    break;

                case 3: // Cocinero

                    btnCocina.Visible = true;

                    break;

                case 4: // Mesero

                    btnMesas.Visible = true;

                    break;

                case 5: // Supervisor

                    btnDashboard.Visible = true;
                    btnMesas.Visible = true;
                    btnCocina.Visible = true;
                    btnCaja.Visible = true;
                    btnReservaciones.Visible = true;
                    btnReportes.Visible = true;

                    break;
            }
        }
    }

}

