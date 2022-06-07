using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Response
{
    /// <summary>
    /// the response model send by the AgenciaTributaria
    /// </summary>
    public class AgenciaTributariaResponse
    {
        /// <summary>
        /// the xml response document
        /// </summary>
        public string ResponseXmlFilePath { get; set; }
    }
}
