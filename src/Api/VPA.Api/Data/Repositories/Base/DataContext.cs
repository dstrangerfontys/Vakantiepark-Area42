using System.Data;
using MySql.Data.MySqlClient;

namespace VPA.Api.Repositories
{
    public sealed class DataContext : IDisposable
    {
        private readonly DataContextOptions options;

        private MySqlConnection _connection;

        public DataContext(DataContextOptions options)
        {
            this.options = options;
        }

        public MySqlConnection GetConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new MySqlConnection(options.ConnectionString);
                _connection.Open();
            }

            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
