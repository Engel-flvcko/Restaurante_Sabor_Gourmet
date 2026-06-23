using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class ValidacionesOrdenes
    {
        // ============================================================
        //  GENERALES (Parte 7 del prompt maestro)
        // ============================================================

        /// <summary>Ningún campo obligatorio puede quedar vacío.</summary>
        public static bool CampoVacio(string valor)
        {
            return string.IsNullOrWhiteSpace(valor);
        }

        /// <summary>Contraseñas mínimo 6 caracteres.</summary>
        public static bool ContrasenaValida(string contrasena)
        {
            return !string.IsNullOrWhiteSpace(contrasena) && contrasena.Trim().Length >= 6;
        }

        /// <summary>Valida que el teléfono tenga solo dígitos, espacios o guiones, y al menos 7 caracteres.</summary>
        public static bool TelefonoValido(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono)) return false;

            string limpio = telefono.Trim();
            if (limpio.Length < 7) return false;

            return limpio.All(c => char.IsDigit(c) || c == '-' || c == ' ' || c == '+');
        }

        /// <summary>La fecha de ingreso no puede ser una fecha futura.</summary>
        public static bool FechaIngresoValida(DateTime fecha)
        {
            return fecha.Date <= DateTime.Now.Date;
        }

        /// <summary>Username único dentro de una lista ya cargada en memoria (validación rápida en cliente).</summary>
        public static bool UsernameDuplicado(IEnumerable<string> usernamesExistentes, string nuevoUsername)
        {
            if (string.IsNullOrWhiteSpace(nuevoUsername)) return false;
            return usernamesExistentes.Any(u =>
                u.Equals(nuevoUsername.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        // ============================================================
        //  MESAS / ÓRDENES
        // ============================================================

        /// <summary>Solo se pueden registrar órdenes en mesas con estado 'Ocupada'.</summary>
        public static bool MesaEstaOcupada(string estadoMesa)
        {
            return estadoMesa == "Ocupada";
        }

        /// <summary>Toda orden debe tener al menos un producto.</summary>
        public static bool OrdenTieneProductos(int cantidadProductosEnDetalle)
        {
            return cantidadProductosEnDetalle > 0;
        }

        /// <summary>La cantidad de un producto en el detalle debe ser mayor a 0.</summary>
        public static bool CantidadValida(int cantidad)
        {
            return cantidad > 0;
        }

        /// <summary>No se puede modificar (agregar/quitar productos) una orden que ya no está 'abierta'.</summary>
        public static bool OrdenSePuedeModificar(string estadoOrden)
        {
            return estadoOrden == "abierta";
        }

        /// <summary>Solo se puede solicitar cierre de cuenta si la orden está 'abierta'.</summary>
        public static bool OrdenSePuedeCerrar(string estadoOrden)
        {
            return estadoOrden == "abierta";
        }

        /// <summary>Solo un supervisor puede cancelar una orden ya enviada a cocina.</summary>
        public static bool PuedeCancelarOrden(string nombreRolUsuario)
        {
            return nombreRolUsuario == "Supervisor" || nombreRolUsuario == "Gerente";
        }

        // ============================================================
        //  COCINA
        // ============================================================

        // Orden numérico del flujo de estados (no se puede retroceder)
        private static readonly Dictionary<string, int> ordenEstadosCocina = new Dictionary<string, int>
        {
            { "pendiente", 1 },
            { "en_preparacion", 2 },
            { "lista", 3 },
            { "entregada", 4 }
        };

        /// <summary>
        /// Valida que el cambio de estado en cocina sea hacia el SIGUIENTE estado
        /// del flujo (pendiente → en_preparacion → lista → entregada).
        /// No permite retroceder ni saltar pasos. 'cancelada' se maneja aparte
        /// (solo un supervisor puede cancelar, ver PuedeCancelarOrden).
        /// </summary>
        public static bool TransicionEstadoCocinaValida(string estadoActual, string estadoNuevo)
        {
            if (estadoActual == "entregada" || estadoActual == "cancelada")
                return false; // son estados finales

            if (!ordenEstadosCocina.ContainsKey(estadoActual) || !ordenEstadosCocina.ContainsKey(estadoNuevo))
                return false;

            return ordenEstadosCocina[estadoNuevo] == ordenEstadosCocina[estadoActual] + 1;
        }

        /// <summary>Una orden en cocina se considera retrasada si superó el límite de minutos sin finalizar.</summary>
        public static bool OrdenEstaRetrasada(DateTime horaRecepcion, int minutosLimite = 30)
        {
            return (DateTime.Now - horaRecepcion).TotalMinutes >= minutosLimite;
        }

        // ============================================================
        //  RESULTADO DE VALIDACIÓN CON MENSAJE
        //  (helper opcional para no repetir MessageBox.Show en cada form)
        // ============================================================
        public class ResultadoValidacion
        {
            public bool EsValido { get; set; }
            public string Mensaje { get; set; }

            public static ResultadoValidacion Ok() => new ResultadoValidacion { EsValido = true, Mensaje = "" };
            public static ResultadoValidacion Error(string mensaje) => new ResultadoValidacion { EsValido = false, Mensaje = mensaje };
        }

        /// <summary>Validación agrupada para el formulario de Meseros (Guardar/Actualizar).</summary>
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

        /// <summary>Validación agrupada para enviar una orden a cocina.</summary>
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

