using System.Data;
using Microsoft.Data.SqlClient;

namespace VPA.Api.Repositories
{
    public sealed class DataContext : IDisposable
    {
        private readonly DataContextOptions options;

        private SqlConnection _connection;

        public DataContext(DataContextOptions options)
        {
            this.options = options;
        }

        public async Task<SqlConnection> GetConnectionAsync(CancellationToken ct = default)
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(options.ConnectionString);
                await _connection.OpenAsync(ct);
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
