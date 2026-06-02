using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Services
{
    internal class CodigoFiscalGenerator
    {
        private int consecutivo = 1;

        public CodigoFiscalGenerator()
        {
            consecutivo = 1;
        }

        public string GenerarCodigoFiscal()
        {
            string codigoFiscal = $"FAC-{DateTime.Now:yyyyMMdd}-{consecutivo:D6}";
            consecutivo++;
            return codigoFiscal;
        }
    }
}
