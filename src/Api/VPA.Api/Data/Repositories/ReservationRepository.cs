using VPA.Models;

namespace VPA.Api.Repositories
{
    public class ReservationRepository : RepositoryBase
    {
        public ReservationRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public Task<IEnumerable<Reservation>> GetAsync(CancellationToken ct = default)
        {
            const string sql =
                """
                SELECT
                    r.ReservationId,
                    r.GuestId,
                    r.RoomId,
                    r.CheckInDate,
                    r.CheckOutDate,
                FROM reservations r
                """;

            return QueryAsync<Reservation>(sql, ct);
        }

        public Task<Reservation> GetByIdAsync(int id, CancellationToken ct = default)
        {
            const string sql =
                """
                SELECT
                    r.ReservationId,
                    r.GuestId,
                    r.RoomId,
                    r.CheckInDate,
                    r.CheckOutDate,
                FROM reservations r
                WHERE r.ReservationId = @Id
                """;

            var param = new { Id = id };

            return QuerySingleOrDefaultAsync<Reservation>(sql, param, ct);
        }

        public Task<int> InsertAsync(Reservation reservation, CancellationToken ct = default)
        {
            const string sql =
                """
                INSERT INTO reservations (GuestId, RoomId, CheckInDate, CheckOutDate)
                VALUES (@GuestId, @RoomId, @CheckInDate, @CheckOutDate)
                """;

            var param = new
            {
                reservation.GuestId,
                reservation.RoomId,
                reservation.CheckInDate,
                reservation.CheckOutDate,
            };

            return ExecuteAsync(sql, param, ct);
        }

        public Task<int> UpdateAsync(int id, Reservation reservation, CancellationToken ct = default)
        {
            const string sql =
                """
                UPDATE reservations
                SET GuestId = @GuestId,
                    RoomId = @RoomId,
                    CheckInDate = @CheckInDate,
                    CheckOutDate = @CheckOutDate,
                WHERE ReservationId = @Id
                """;

            var param = new
            {
                Id = id,
                reservation.GuestId,
                reservation.RoomId,
                reservation.CheckInDate,
                reservation.CheckOutDate,
            };

            return ExecuteAsync(sql, param, ct);
        }

        public Task<int> DeleteAsync(int id, CancellationToken ct = default)
        {
            const string sql =
                """
                DELETE FROM reservations
                WHERE ReservationId = @Id
                """;

            var param = new { Id = id };

            return ExecuteAsync(sql, param, ct);
        }
    }
}
