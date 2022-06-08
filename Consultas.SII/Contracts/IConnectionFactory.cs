using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Contracts
{
    public interface IConnectionFactory
    {
        int CommandTimeout { get; }
        IDbConnection GetPuenteSiiDatabaseConnectionString { get; }
    }
}
