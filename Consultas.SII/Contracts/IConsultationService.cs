using Consultas.SII.Entities;
using Consultas.SII.Entities.Model.BaseType.Consulta.Request.Contraste;
using Consultas.SII.Entities.Request;

using Gesisa.Apps.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Contracts
{
    public interface IConsultationService
    {
        Task<ListResult<ERegistroInformacion>> ConsultaLRAsync(ConsultaFacturasRequest request, ConsultaClavePaginacion clavePaginacion = null);

    }
}
