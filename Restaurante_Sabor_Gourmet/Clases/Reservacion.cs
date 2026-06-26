using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class Reservacion
    {
        public int IdReservacion { get; set; }

        public string NombreCliente { get; set; }
        public string TelefonoCliente { get; set; }

        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }

        public int NumPersonas { get; set; }

        public string Tipo { get; set; }

        public string NombreEvento { get; set; }

        public string Estado { get; set; }

        public int IdEmpleadoRegistro { get; set; }

        public string FechaFormateada => Fecha.ToString("dd/MM/yyyy");

        
        public string HoraFormateada => HoraInicio.ToString(@"hh\:mm");

        
        public string EstadoDisplay =>
            string.IsNullOrEmpty(Estado)
                ? ""
                : char.ToUpper(Estado[0]) + Estado.Substring(1).ToLower();

       
        public string TipoDisplay =>
            string.IsNullOrEmpty(Tipo)
                ? ""
                : char.ToUpper(Tipo[0]) + Tipo.Substring(1).ToLower();

        public Reservacion()
        {
            NombreCliente = "";
            TelefonoCliente = "";
            Tipo = "Simple";
            NombreEvento = "";
            Estado = "pendiente";
            Fecha = DateTime.Now.AddDays(1).Date;
            HoraInicio = new TimeSpan(12, 0, 0);
            NumPersonas = 1;
        }
    }
}