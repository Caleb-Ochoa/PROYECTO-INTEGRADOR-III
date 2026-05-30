using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces
{
    internal interface IFacturaService
    {
        Factura GenerarFactura(int cotizacionId);

        void AnularFactura(int facturaId);
    }
}
