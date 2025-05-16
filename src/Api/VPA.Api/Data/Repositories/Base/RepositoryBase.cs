using Dapper;
using Microsoft.Data.SqlClient;

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
            await using SqlConnection connection = await DataContext.GetConnectionAsync(ct);

            return await connection.QueryAsync<TResult>(sql, param);
        }

        protected Task<TResult> QuerySingleAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return QuerySingleAsync<TResult>(sql, null, ct);
        }

        protected async Task<TResult> QuerySingleAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using SqlConnection connection = await DataContext.GetConnectionAsync(ct);

            return await connection.QuerySingleAsync<TResult>(sql, param);
        }

        protected Task<TResult> QuerySingleOrDefaultAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return QuerySingleOrDefaultAsync<TResult>(sql, null, ct);
        }

        protected async Task<TResult> QuerySingleOrDefaultAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using SqlConnection connection = await DataContext.GetConnectionAsync(ct);

            return await connection.QuerySingleOrDefaultAsync<TResult>(sql, param);
        }

        protected Task<TResult> QueryFirstAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return QueryFirstAsync<TResult>(sql, null, ct);
        }

        protected async Task<TResult> QueryFirstAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using SqlConnection connection = await DataContext.GetConnectionAsync(ct);

            return await connection.QueryFirstAsync<TResult>(sql, param);
        }

        protected Task<TResult> QueryFirstOrDefaultAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return QueryFirstOrDefaultAsync<TResult>(sql, null, ct);
        }

        protected async Task<TResult> QueryFirstOrDefaultAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using SqlConnection connection = await DataContext.GetConnectionAsync(ct);

            return await connection.QueryFirstOrDefaultAsync<TResult>(sql, param);
        }

        protected Task<TResult> ExecuteScalarAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return ExecuteScalarAsync<TResult>(sql, null, ct);
        }

        protected async Task<TResult> ExecuteScalarAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using SqlConnection connection = await DataContext.GetConnectionAsync(ct);

            return await connection.ExecuteScalarAsync<TResult>(sql, param);
        }

        protected Task<int> ExecuteAsync(string sql, CancellationToken ct = default)
        {
            return ExecuteAsync(sql, null, ct);
        }

        protected async Task<int> ExecuteAsync(string sql, object param, CancellationToken ct = default)
        {
            await using SqlConnection connection = await DataContext.GetConnectionAsync(ct);

            return await connection.ExecuteAsync(sql, param);
        }
    }
}
