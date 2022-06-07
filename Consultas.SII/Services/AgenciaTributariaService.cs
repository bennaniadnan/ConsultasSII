using Consultas.SII.Contracts;
using Consultas.SII.Entities.Response;

using Gesisa.Apps.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Services
{
    public class AgenciaTributariaService : IAgenciaTributariaService
    {
        public Result<Task<AgenciaTributariaResponse>> SendXmlRequestAsync(string agency, string invoiceType, string xmlRequestFilePath)
        {
            throw new NotImplementedException();
        }
    }
}
