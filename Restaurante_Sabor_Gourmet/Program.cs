using Restaurante_Sabor_Gourmet.Formularios;
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
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmLogin());

        }
    }
}