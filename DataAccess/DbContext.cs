using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class DbContext
	{
		private readonly string _connectionString;

		public DbContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		public SqlConnection CreateConnection()
		{
			return new SqlConnection(_connectionString);
		}
	}
}
