using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VPA.Models;
using VPA.Website.Client;

namespace VPA.Website.Pages.Store
{
    public class LocationsModel : PageModel
    {
        private readonly StoreLocationClient locationClient;

        public LocationsModel(StoreLocationClient locationClient)
        {
            this.locationClient = locationClient;
        }

        [BindProperty]
        public List<StoreLocation> Locations { get; private set; } = new();

        [BindProperty]
        public StoreLocation NewLocation { get; set; } = new();

        public async Task OnGetAsync(CancellationToken ct = default)
        {
            await LoadAsync(ct);
        }

        public async Task OnPostAsync(CancellationToken ct = default)
        {
            await locationClient.CreateAsync(NewLocation, ct);
            await LoadAsync(ct);
        }

        private async Task LoadAsync(CancellationToken ct = default)
        {
            Locations = await locationClient.GetAsync(ct);
        }
    }
}
