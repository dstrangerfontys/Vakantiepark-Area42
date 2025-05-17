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

        public Task<int> InsertAsync(Article article, CancellationToken ct = default)
        {
            const string sql = """
                INSERT INTO Article (Name, Price)
                VALUES (@Name, @Price)
                """;

            var param = new
            {
                Name = article.Name,
                Price = article.Price,
            };

            return ExecuteAsync(sql, param, ct);
        }

        public Task<int> UpdateAsync(int id, Article article, CancellationToken ct = default)
        {
            const string sql = """
                UPDATE Article
                SET Name = @Name,
                    Price = @Price
                WHERE Id = @Id
                """;

            var param = new
            {
                Id = id,
                Name = article.Name,
                Price = article.Price,
            };

            return ExecuteAsync(sql, param, ct);
        }

        public Task<int> DeleteAsync(int id, CancellationToken ct = default)
        {
            const string sql = """
                DELETE FROM Article
                WHERE Id = @Id
                """;

            var param = new
            {
                Id = id,
            };

            return ExecuteAsync(sql, param, ct);
        }
    }
}
