using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Services
{
    internal class CodigoFiscalGenerator
    {
        private readonly DataManager<Factura> _dm;

        public CodigoFiscalGenerator(DataManager<Factura> dm) => _dm = dm;

        /// <summary>
        /// Genera un código único basado en la fecha y el siguiente Id de factura,
        /// garantizando que no haya duplicados aunque el programa se reinicie.
        /// </summary>
        public string Generar()
        {
            int nextId = _dm.GetNextId();
            return $"FAC-{DateTime.Now:yyyyMMdd}-{nextId:D6}";
        }
    }
}
