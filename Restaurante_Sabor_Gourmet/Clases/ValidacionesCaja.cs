using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Engel.clases
{
    internal class ValidacionesCaja
    {
        //CAJA frmCaja_Arqueo 

        public bool ValidarArqueoAbierto(int idArqueoActivo)
        {
            if (idArqueoActivo == -1)
            {
                MessageBox.Show(
                    "No hay una caja abierta. Ve al tab 'Arqueo de Caja' y abre la caja primero.",
                    "Sin caja abierta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool ValidarCuentaSeleccionada(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Selecciona una cuenta de la lista.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool ValidarPagoEfectivo(decimal montoRecibido, decimal totalFinal)
        {
            if (montoRecibido < totalFinal)
            {
                MessageBox.Show(
                    "El monto recibido es menor al total a cobrar.",
                    "Monto insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool ValidarPagoMixto(decimal efectivo, decimal tarjeta, decimal totalFinal)
        {
            decimal suma = efectivo + tarjeta;
            if (suma < totalFinal)
            {
                MessageBox.Show(
                    $"La suma del pago mixto ({suma:C2}) es menor al total ({totalFinal:C2}).",
                    "Pago mixto incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool ValidarFondoInicial(decimal fondo)
        {
            if (fondo < 0)
            {
                MessageBox.Show(
                    "El fondo inicial no puede ser negativo.",
                    "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool ValidarTotalContado(decimal totalContado)
        {
            if (totalContado < 0)
            {
                MessageBox.Show(
                    "El total contado no puede ser negativo.",
                    "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //  DASHBOARD  frmDashboard 

        public bool ValidarRangoFechas(DateTime desde, DateTime hasta)
        {
            if (desde > hasta)
            {
                MessageBox.Show(
                    "La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.",
                    "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //  SUPERVISIÓN DESCUENTOS  frmSupervision 

        public bool ValidarOrdenSeleccionadaDescuento(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Selecciona una orden de la tabla.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool ValidarMotivoDescuento(string motivo)
        {
            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show(
                    "El motivo del descuento es obligatorio.",
                    "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //SUPERVISIÓN  PROMOCIONES frmSupervision 

        public bool ValidarNombrePromocion(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(
                    "El nombre de la promoción es obligatorio.",
                    "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool ValidarFechasPromocion(DateTime inicio, DateTime fin)
        {
            if (fin <= inicio)
            {
                MessageBox.Show(
                    "La fecha fin debe ser posterior a la fecha inicio.",
                    "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool ValidarPromocionSeleccionada(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Selecciona una promoción de la lista.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}