using Consultas.SII.Contracts;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Services
{

	public class ConnectionFactory : IConnectionFactory
	{
		private readonly IConfiguration _config;
		private readonly IDbConnection _connection;
		private readonly int _commandTimeout = 60;

		public ConnectionFactory(IConfiguration configuration, IDbConnection connection)
		{
			_config = configuration;
			_connection = connection;
			_commandTimeout = 120;
		}

		public IDbConnection GetPuenteSiiDatabaseConnectionString
		{
			get
			{
				_connection.ConnectionString = _config.GetConnectionString("PuenteSiiDatabase");
				return _connection;
			}
		}

		public int CommandTimeout { get { return _commandTimeout; } }

	}
}
