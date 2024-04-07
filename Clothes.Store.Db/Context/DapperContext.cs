using Microsoft.Extensions.Configuration;

using System.Data;
using System.Data.SqlClient;


namespace Clothes.Store.Db.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
       
        private readonly string _connectionString;
        public DapperContext(IConfiguration _configuration)
        {
            _configuration = _configuration ?? throw new ArgumentNullException();
            _connectionString = _configuration.GetConnectionString("DbConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}
