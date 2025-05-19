using VPA.Api.Repositories;
using VPA.Api.Services;
using VPA.Models;

namespace VPA.Api.BusinessLogic.Services
{
    public class Reservationservice : IService
    {
        private readonly ReservationRepository repository;

        public Reservationservice(ReservationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Reservation>> GetAsync(CancellationToken ct = default)
        {
            // Ophalen van alle reserveringen uit de database
            var allReservations = await repository.GetAsync(ct);

            // Toegevoegde logica: enkel reserveringen die nog niet zijn afgelopen
            var upcomingOrOngoing = allReservations
                .Where(r => r.CheckOutDate >= DateTime.Today)
                .OrderBy(r => r.CheckInDate);

            return upcomingOrOngoing;
        }
    }
}
