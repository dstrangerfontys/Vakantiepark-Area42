using Dapper;
using Microsoft.Data.SqlClient;

namespace VPA.Api.Repositories
{
    public class RepositoryBase
    {
        protected RepositoryBase(DbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        protected DbContext DbContext { get; init; }

        protected Task<IEnumerable<TResult>> QueryAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return QueryAsync<TResult>(sql, null, ct);
        }

        protected async Task<IEnumerable<TResult>> QueryAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using SqlConnection connection = await DbContext.GetConnectionAsync(ct);

            return await connection.QueryAsync<TResult>(sql, param);
        }

        protected Task<TResult> QuerySingleAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return QuerySingleAsync<TResult>(sql, null, ct);
        }

        protected async Task<TResult> QuerySingleAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using SqlConnection connection = await DbContext.GetConnectionAsync(ct);

            return await connection.QuerySingleAsync<TResult>(sql, param);
        }

        protected Task<TResult> QuerySingleOrDefaultAsync<TResult>(string sql, CancellationToken ct = default)
        {
            return QuerySingleOrDefaultAsync<TResult>(sql, null, ct);
        }

        protected async Task<TResult> QuerySingleOrDefaultAsync<TResult>(string sql, object param, CancellationToken ct = default)
        {
            await using SqlConnection connection = await DbContext.GetConnectionAsync(ct);

            return await connection.QuerySingleOrDefaultAsync<TResult>(sql, param);
        }
    }
}
