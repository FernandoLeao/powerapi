using Power.Repository;
using System.Data;
using System.Data.SqlClient;

namespace Power.Infra.DataBase.Connection
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {

        private readonly IConnectionStringProvider _connectionStringProvider;

        public SqlConnectionFactory(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public IDbConnection GetInstance()
        {
            var cn = new SqlConnection(_connectionStringProvider.GetConnectionString());
            cn.Open();
            return cn;
        }

    }
}
