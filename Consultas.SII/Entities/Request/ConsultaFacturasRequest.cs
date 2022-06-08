using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Request
{
    public class ConsultaFacturasRequest
    {
        public string IdAgencia { get; set; }
        public string IdLibroRegistro { get; set; }
        public int Ejercicio { get; set; }
        public string Periodo { get; set; }
        public string CompanyNif { get; internal set; }
        public string CompanyDenomination { get; internal set; }
    }
}
