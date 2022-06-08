using System;
using System.Collections.Generic;
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
			_commandTimeout = int.Parse(_config.GetSection("ConnectionTimeout").Value);
		}

		public IDbConnection GetConnectionByUser(DataUser dataUser)
		{
			if (string.IsNullOrEmpty(_connection.ConnectionString) || dataUser.ConnectionString != _connection.ConnectionString)
			{
				_connection.ConnectionString = dataUser.ConnectionString;

			}
			return _connection;
		}

		public IDbConnection GetSiiAuthenticationConnectionString
		{
			get
			{
				_connection.ConnectionString = _config.GetConnectionString("SiiCoreAuthentication");
				return _connection;
			}
		}
		public IDbConnection GetPuenteSiiAuthenticationConnectionString
		{
			get
			{
				_connection.ConnectionString = _config.GetConnectionString("PuenteSiiAuthentication");
				return _connection;
			}
		}

		public IDbConnection GetSiiHubConnectionString
		{
			get
			{
				_connection.ConnectionString = _config.GetConnectionString("HubConnectionString");
				return _connection;
			}
		}

		public int CommandTimeout { get { return _commandTimeout; } }

	}
}
