using Consultas.SII.Entities.Response;

using Gesisa.Apps.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Contracts
{
    public interface IAgenciaTributariaService
    {
        /// <summary>
        /// send the Xml Request for the given agency with the given invoice type
        /// </summary>
        /// <param name="userId">the id of the user this request associated with it</param>
        /// <param name="agency">the agency name</param>
        /// <param name="invoiceType">the invoice type</param>
        /// <param name="xmlRequestFilePath">the xml request file path</param>
        /// <returns></returns>
        Task<Result<AgenciaTributariaResponse>> SendXmlRequestAsync(string agency, string invoiceType, string xmlRequestFilePath);

    }
}
