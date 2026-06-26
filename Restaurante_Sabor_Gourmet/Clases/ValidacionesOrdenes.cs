using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class ValidacionesOrdenes
    {
        public static bool CampoVacio(string valor)
        {
            return string.IsNullOrWhiteSpace(valor);
        }

        public static bool ContrasenaValida(string contrasena)
        {
            return !string.IsNullOrWhiteSpace(contrasena) && contrasena.Trim().Length >= 6;
        }

        public static bool TelefonoValido(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono)) return false;

            string limpio = telefono.Trim();
            if (limpio.Length < 7) return false;

            return limpio.All(c => char.IsDigit(c) || c == '-' || c == ' ' || c == '+');
        }

        public static bool FechaIngresoValida(DateTime fecha)
        {
            return fecha.Date <= DateTime.Now.Date;
        }

        public static bool UsernameDuplicado(IEnumerable<string> usernamesExistentes, string nuevoUsername)
        {
            if (string.IsNullOrWhiteSpace(nuevoUsername)) return false;
            return usernamesExistentes.Any(u =>
                u.Equals(nuevoUsername.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public static bool MesaEstaOcupada(string estadoMesa)
        {
            return estadoMesa == "Ocupada";
        }

        public static bool OrdenTieneProductos(int cantidadProductosEnDetalle)
        {
            return cantidadProductosEnDetalle > 0;
        }

        public static bool CantidadValida(int cantidad)
        {
            return cantidad > 0;
        }

        public static bool OrdenSePuedeModificar(string estadoOrden)
        {
            return estadoOrden == "abierta";
        }

        public static bool OrdenSePuedeCerrar(string estadoOrden)
        {
            return estadoOrden == "abierta";
        }

        public static bool PuedeCancelarOrden(string nombreRolUsuario)
        {
            return nombreRolUsuario == "Supervisor" || nombreRolUsuario == "Gerente";
        }

        private static readonly Dictionary<string, int> ordenEstadosCocina = new Dictionary<string, int>
        {
            { "pendiente", 1 },
            { "en_preparacion", 2 },
            { "lista", 3 },
            { "entregada", 4 }
        };

        public static bool TransicionEstadoCocinaValida(string estadoActual, string estadoNuevo)
        {
            if (estadoActual == "entregada" || estadoActual == "cancelada")
                return false; 

            if (!ordenEstadosCocina.ContainsKey(estadoActual) || !ordenEstadosCocina.ContainsKey(estadoNuevo))
                return false;

            return ordenEstadosCocina[estadoNuevo] == ordenEstadosCocina[estadoActual] + 1;
        }

        public static bool OrdenEstaRetrasada(DateTime horaRecepcion, int minutosLimite = 30)
        {
            return (DateTime.Now - horaRecepcion).TotalMinutes >= minutosLimite;
        }

        public class ResultadoValidacion
        {
            public bool EsValido { get; set; }
            public string Mensaje { get; set; }

            public static ResultadoValidacion Ok() => new ResultadoValidacion { EsValido = true, Mensaje = "" };
            public static ResultadoValidacion Error(string mensaje) => new ResultadoValidacion { EsValido = false, Mensaje = mensaje };
        }

        public static ResultadoValidacion ValidarMesero(string nombreCompleto, string username,
            string telefono, string contrasena, bool esNuevo, IEnumerable<string> usernamesExistentes)
        {
            if (CampoVacio(nombreCompleto))
                return ResultadoValidacion.Error("El nombre completo es obligatorio.");

            if (CampoVacio(username))
                return ResultadoValidacion.Error("El username es obligatorio.");

            if (!TelefonoValido(telefono))
                return ResultadoValidacion.Error("El teléfono no es válido (mínimo 7 dígitos).");

            if (esNuevo && CampoVacio(contrasena))
                return ResultadoValidacion.Error("La contraseña es obligatoria para un nuevo mesero.");

            if (!string.IsNullOrWhiteSpace(contrasena) && !ContrasenaValida(contrasena))
                return ResultadoValidacion.Error("La contraseña debe tener al menos 6 caracteres.");

            if (esNuevo && UsernameDuplicado(usernamesExistentes, username))
                return ResultadoValidacion.Error("Ya existe un mesero con ese username.");

            return ResultadoValidacion.Ok();
        }

        public static ResultadoValidacion ValidarEnvioOrden(int idMesaSeleccionada, int cantidadProductos, string estadoMesa)
        {
            if (idMesaSeleccionada == 0)
                return ResultadoValidacion.Error("Selecciona una mesa antes de enviar la orden.");

            if (!MesaEstaOcupada(estadoMesa))
                return ResultadoValidacion.Error("Solo se pueden registrar órdenes en mesas ocupadas.");

            if (!OrdenTieneProductos(cantidadProductos))
                return ResultadoValidacion.Error("Agrega al menos un producto a la orden.");

            return ResultadoValidacion.Ok();
        }
    }
}