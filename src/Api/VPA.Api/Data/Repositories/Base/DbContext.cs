using System.Data;
using Microsoft.Data.SqlClient;

namespace VPA.Api.Repositories
{
    public sealed class DbContext : IDisposable
    {
        private const string ConnectionString = "Server=paneldatabase.humbleservers.com;Port=3306;Database=s26125_VakantiePark;User=u26125_Ppl6BlvLQ4;Password=^nevb@Hp2!SLqen.4rqO3oNM;";

        private SqlConnection _connection;

        public async Task<SqlConnection> GetConnectionAsync(CancellationToken ct = default)
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(ConnectionString);
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
