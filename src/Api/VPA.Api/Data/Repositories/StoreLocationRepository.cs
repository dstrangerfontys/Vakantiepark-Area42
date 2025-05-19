using VPA.Models;

namespace VPA.Api.Repositories
{
    public class StoreLocationRepository : RepositoryBase
    {
        public StoreLocationRepository(DataContext dataContext)
            : base(dataContext)
        {
            //
        }

        public Task<IEnumerable<StoreLocation>> GetAsync(CancellationToken ct = default)
        {
            const string sql =
                """
                SELECT
                    sl.*
                FROM StoreLocation sl
                """;

            return QueryAsync<StoreLocation>(sql, ct);
        }

        public Task<StoreLocation> GetByIdAsync(int id, CancellationToken ct = default)
        {
            const string sql =
                """
                SELECT
                    sl.*
                FROM StoreLocation sl
                WHERE sl.Id = @Id
                """;

            var param = new
            {
                Id = id,
            };

            return QuerySingleOrDefaultAsync<StoreLocation>(sql, param, ct);
        }

        public Task<int> InsertAsync(StoreLocation storeLocation, CancellationToken ct = default)
        {
            const string sql = """
                INSERT INTO StoreLocation (Name, Row, Height)
                VALUES (@Name, @Row, @Height)
                """;

            var param = new
            {
                Name = storeLocation.Name,
                Row = storeLocation.Row,
                Height = storeLocation.Height,
            };

            return ExecuteAsync(sql, param, ct);
        }

        public Task<int> UpdateAsync(int id, StoreLocation storeLocation, CancellationToken ct = default)
        {
            const string sql = """
                UPDATE StoreLocation
                SET Name = @Name,
                    Row = @Row,
                    Height = @Height
                WHERE Id = @Id
                """;

            var param = new
            {
                Id = id,
                Name = storeLocation.Name,
                Row = storeLocation.Row,
                Height = storeLocation.Height,
            };

            return ExecuteAsync(sql, param, ct);
        }

        public Task<int> DeleteAsync(int id, CancellationToken ct = default)
        {
            const string sql = """
                DELETE FROM StoreLocation
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
