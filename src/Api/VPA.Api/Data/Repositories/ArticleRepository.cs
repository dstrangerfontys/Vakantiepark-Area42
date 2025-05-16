using VPA.Models;

namespace VPA.Api.Repositories
{
    public class ArticleRepository : RepositoryBase
    {
        public ArticleRepository(DataContext dataContext)
            : base(dataContext)
        {
            //
        }

        public Task<IEnumerable<Article>> GetAsync(CancellationToken ct = default)
        {
            const string sql =
                """
                SELECT
                    a.*
                FROM Article a
                """;

            return QueryAsync<Article>(sql, ct);
        }

        public Task<Article> GetByIdAsync(int id, CancellationToken ct = default)
        {
            const string sql =
                """
                SELECT
                    a.*
                FROM Article a
                WHERE a.Id = @Id
                """;

            var param = new
            {
                Id = id,
            };

            return QuerySingleOrDefaultAsync<Article>(sql, param, ct);
        }
    }
}
