using VPA.Models;

namespace VPA.Api.Repositories
{
    public class ReservationRepository : RepositoryBase
    {
        public ReservationRepository(DataContext dataContext)
            : base(dataContext)
        {
            //
        }

        public Task<IEnumerable<Reservation>> GetAsync(CancellationToken ct = default)
        {
            const string sql =
                """
                SELECT
                    r.*
                FROM Reservation r
                """;

            return QueryAsync<Reservation>(sql, ct);
        }

        public Task<Reservation> GetByIdAsync(int id, CancellationToken ct = default)
        {
            const string sql =
                """
                SELECT
                    r.*
                FROM Reservation r
                WHERE a.Id = @Id
                """;

            var param = new
            {
                Id = id,
            };

            return QuerySingleOrDefaultAsync<Reservation>(sql, param, ct);
        }

        public Task<int> InsertAsync(Reservation reservation, CancellationToken ct = default)
        {
            const string sql = """
                INSERT INTO Reservation (Name, Price)
                VALUES (@Name, @Price)
                """;

            var param = new
            {
                Name = reservation.Name,
                Price = reservation.Price,
            };

            return ExecuteAsync(sql, param, ct);
        }

        public Task<int> UpdateAsync(int id, Reservation reservation, CancellationToken ct = default)
        {
            const string sql = """
                UPDATE Reservation
                SET Name = @Name,
                    Price = @Price
                WHERE Id = @Id
                """;

            var param = new
            {
                Id = id,
                Name = reservation.Name,
                Price = reservation.Price,
            };

            return ExecuteAsync(sql, param, ct);
        }

        public Task<int> DeleteAsync(int id, CancellationToken ct = default)
        {
            const string sql = """
                DELETE FROM Reservation
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
