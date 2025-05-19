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

        public Task<IEnumerable<Reservation>> GetAsync(CancellationToken ct = default)
        {
            // Hier kunnen we eventueel logica toevoegen

            return repository.GetAsync(ct);
        }
    }
}
