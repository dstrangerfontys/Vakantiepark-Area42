using Dapper;
using MySql.Data.MySqlClient;

namespace VPA.Api.Repositories
{
    public class RepositoryBase
    {
        protected RepositoryBase(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        protected DataContext DataContext { get; init; }

        protected Task<IEnumerable<TResult>> QueryAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return QueryAsync<TResult>(sql, null, ct);
        }

        protected async Task<IEnumerable<TResult>> QueryAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using MySqlConnection connection = DataContext.GetConnection();

            return await connection.QueryAsync<TResult>(new CommandDefinition(sql, param, cancellationToken: ct));
        }

        protected Task<TResult> QuerySingleAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return QuerySingleAsync<TResult>(sql, null, ct);
        }

        protected async Task<TResult> QuerySingleAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using MySqlConnection connection = DataContext.GetConnection();

            return await connection.QuerySingleAsync<TResult>(new CommandDefinition(sql, param, cancellationToken: ct));
        }

        protected Task<TResult> QuerySingleOrDefaultAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return QuerySingleOrDefaultAsync<TResult>(sql, null, ct);
        }

        protected async Task<TResult> QuerySingleOrDefaultAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using MySqlConnection connection = DataContext.GetConnection();

            return await connection.QuerySingleOrDefaultAsync<TResult>(new CommandDefinition(sql, param, cancellationToken: ct));
        }

        protected Task<TResult> QueryFirstAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return QueryFirstAsync<TResult>(sql, null, ct);
        }

        protected async Task<TResult> QueryFirstAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using MySqlConnection connection = DataContext.GetConnection();

            return await connection.QueryFirstAsync<TResult>(new CommandDefinition(sql, param, cancellationToken: ct));
        }

        protected Task<TResult> QueryFirstOrDefaultAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return QueryFirstOrDefaultAsync<TResult>(sql, null, ct);
        }

        protected async Task<TResult> QueryFirstOrDefaultAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using MySqlConnection connection = DataContext.GetConnection();

            return await connection.QueryFirstOrDefaultAsync<TResult>(new CommandDefinition(sql, param, cancellationToken: ct));
        }

        protected Task<TResult> ExecuteScalarAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return ExecuteScalarAsync<TResult>(sql, null, ct);
        }

        protected async Task<TResult> ExecuteScalarAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using MySqlConnection connection = DataContext.GetConnection();

            return await connection.ExecuteScalarAsync<TResult>(new CommandDefinition(sql, param, cancellationToken: ct));
        }

        protected Task<int> ExecuteAsync(string sql, CancellationToken ct = default)
        {
            return ExecuteAsync(sql, null, ct);
        }

        protected async Task<int> ExecuteAsync(string sql, object param, CancellationToken ct = default)
        {
            await using MySqlConnection connection = DataContext.GetConnection();

            return await connection.ExecuteAsync(new CommandDefinition(sql, param, cancellationToken: ct));
        }
    }
}
