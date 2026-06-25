using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class Reservacion
    {
        // ── Clave primaria ─────────────────────────────────────────────
        public int IdReservacion { get; set; }

        // ── Datos del cliente ──────────────────────────────────────────
        public string NombreCliente { get; set; }
        public string TelefonoCliente { get; set; }

        // ── Fecha y hora ───────────────────────────────────────────────
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }

        // ── Detalles de la reservación ─────────────────────────────────
        public int NumPersonas { get; set; }

        /// <summary>
        /// Valores válidos en BD: 'Simple' | 'Evento'
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Solo obligatorio cuando Tipo = 'Evento'. Puede ser null o vacío.
        /// </summary>
        public string NombreEvento { get; set; }

        /// <summary>
        /// Valores válidos en BD: 'pendiente' | 'confirmada' | 'cancelada' | 'finalizada'
        /// ⚠️ La BD usa minúsculas — al mostrar en pantalla, usar ToTitleCase o comparar
        /// con StringComparison.OrdinalIgnoreCase
        /// </summary>
        public string Estado { get; set; }

        // ── FK al empleado que registró ────────────────────────────────
        public int IdEmpleadoRegistro { get; set; }

        // ── Propiedades de solo lectura (para mostrar en UI) ───────────

        /// <summary>
        /// Fecha formateada para mostrar en pantalla: dd/MM/yyyy
        /// </summary>
        public string FechaFormateada => Fecha.ToString("dd/MM/yyyy");

        /// <summary>
        /// Hora formateada para mostrar en pantalla: HH:mm
        /// </summary>
        public string HoraFormateada => HoraInicio.ToString(@"hh\:mm");

        /// <summary>
        /// Estado con primera letra en mayúscula para mostrar en combos y etiquetas
        /// </summary>
        public string EstadoDisplay =>
            string.IsNullOrEmpty(Estado)
                ? ""
                : char.ToUpper(Estado[0]) + Estado.Substring(1).ToLower();

        /// <summary>
        /// Tipo con primera letra en mayúscula
        /// </summary>
        public string TipoDisplay =>
            string.IsNullOrEmpty(Tipo)
                ? ""
                : char.ToUpper(Tipo[0]) + Tipo.Substring(1).ToLower();

        // ── Constructor vacío ──────────────────────────────────────────
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