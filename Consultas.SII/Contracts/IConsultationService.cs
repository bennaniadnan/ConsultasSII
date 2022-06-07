using Consultas.SII.Entities;
using Consultas.SII.Entities.Request;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Contracts
{
    public interface IConsultationService
    {
        Task<ICollection<ERegistroInformacion>> ConsultaLRAsync(ConsultaFacturasRequest request, ConsultaClavePaginacion clavePaginacion = null);

    }
}
