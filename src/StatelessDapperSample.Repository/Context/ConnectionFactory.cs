using Npgsql;
using StatelessDapperSample.Domain.Data;

namespace StatelessDapperSample.Repository.Context
{
    public class ConnectionFactory
    {
        private readonly ConnectionString _connectionString;
        
        public ConnectionFactory(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString.GetConnectionString);
        }
    }
}
