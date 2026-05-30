using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces
{
    internal interface ICotizacionService
    {
        Cotizacion CrearCotizacion(
            int clienteId,
            int terrenoId,
            int materialId);

        List<Cotizacion> ObtenerTodas();
        Cotizacion? ObtenerPorId(int id);
        void CancelarCotizacion(int id);
    }
}
