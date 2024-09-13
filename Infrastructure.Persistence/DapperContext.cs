using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Persistence
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _dbconnectionString;
        private readonly string _masterconnectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbconnectionString = _configuration.GetConnectionString("OfficesDb");
            _masterconnectionString = _configuration.GetConnectionString("MasterConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_dbconnectionString);
        public IDbConnection CreateMasterConnection()
            => new SqlConnection(_masterconnectionString);
    }
}
