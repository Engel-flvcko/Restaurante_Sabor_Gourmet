//using Restaurante_Sabor_Gourmet.Formularios;
using Restaurante_Sabor_Gourmet.Jaqueline.Formularios;
using Restaurante_Sabor_Gourmet.Vane;

namespace Restaurante_Sabor_Gourmet
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new FrmLogin());
            //Application.Run(new frmRecetas());
            //Application.Run(new FormMenu());
            Application.Run(new frmInventario());
            //hghff
        }
    }
}