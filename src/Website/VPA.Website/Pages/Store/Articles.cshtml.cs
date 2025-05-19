using Microsoft.AspNetCore.Mvc.RazorPages;
using VPA.Models;
using VPA.Website.Client;

namespace VPA.Website.Pages
{
    public class ReservationsModel : PageModel
    {
        private readonly ReservationClient ReservationClient;

        public ReservationsModel(ReservationClient ReservationClient)
        {
            this.ReservationClient = ReservationClient;
        }

        public List<Reservation> Reservations { get; private set; } = new();

        public async Task OnGetAsync(CancellationToken ct = default)
        {
            Reservations = await ReservationClient.GetAsync(ct);
        }

        public async Task CreateAsync(CancellationToken ct = default)
        {
            Reservation Reservation = new Reservation
            {
                Name = "Nieuw artikel",
                Price = 0,
            };

            await ReservationClient.CreateAsync(Reservation, ct);
        }
    }
}
