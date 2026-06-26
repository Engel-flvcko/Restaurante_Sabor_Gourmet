using System;
using Guna.UI2.WinForms;

namespace Restaurante_Sabor_Gourmet.Jaqueline.Clases
{
    internal class PermisosUsuario
    {
        public void ConfigurarBotones(
            Guna2Button btnMesas,
            Guna2Button btnCocina,
            Guna2Button btnMenu,
            Guna2Button btnUsuarios,
            Guna2Button btnRecetas,
            Guna2Button btnInventario,
            Guna2Button btnCaja,
            Guna2Button btnReservaciones,
            Guna2Button btnMeseros,
            Guna2Button btnReportes)
        {
            // Ocultar todos primero
            btnReportes.Visible = false;
            btnMesas.Visible = false;
            btnCocina.Visible = false;
            btnMenu.Visible = false;
            btnUsuarios.Visible = false;
            btnRecetas.Visible = false;
            btnInventario.Visible = false;
            btnCaja.Visible = false;
            btnReservaciones.Visible = false;
            btnMeseros.Visible = false;

            switch (Sesion.IdRol)
            {
                case 1: // Administrador — todo
                    btnMesas.Visible = true;
                    btnCocina.Visible = true;
                    btnMenu.Visible = true;
                    btnUsuarios.Visible = true;
                    btnRecetas.Visible = true;
                    btnInventario.Visible = true;
                    btnCaja.Visible = true;
                    btnReservaciones.Visible = true;
                    btnMeseros.Visible = true;
                    btnReportes.Visible = true;
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
                    btnMesas.Visible = true;
                    btnCocina.Visible = true;
                    btnCaja.Visible = true;
                    btnUsuarios.Visible = true;
                    btnReservaciones.Visible = true;
                    btnMeseros.Visible = true;
                    btnReportes.Visible = true;
                    break;
            }
        }
    }
}