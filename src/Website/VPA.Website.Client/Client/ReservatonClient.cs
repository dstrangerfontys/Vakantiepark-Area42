using VPA.Models;

namespace VPA.Website.Client
{
    public class ReservationClient : ApiClient
    {
        private const string EndPoint = "Reservations";

        public ReservationClient(IHttpClientFactory httpClientFactory, ApiOptions options)
            : base(httpClientFactory, options)
        {
            //
        }

        public Task<List<Reservation>> GetAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<List<Reservation>>($"{EndPoint}", cancellationToken);
        }

        public Task<Reservation> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return GetAsync<Reservation>($"{EndPoint}/{id}", cancellationToken);
        }

        public Task CreateAsync(Reservation reservation, CancellationToken cancellationToken = default)
        {
            return PostAsync($"{EndPoint}", reservation, cancellationToken);
        }

        public Task UpdateAsync(Reservation reservation, CancellationToken cancellationToken = default)
        {
            return PutAsync($"{EndPoint}/{reservation.Id}", reservation, cancellationToken);
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync($"{EndPoint}/{id}", cancellationToken);
        }
    }
}
