using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VPA.Models;

namespace VPA.Website.Pages
{
    public class CreateReservationModel : PageModel
    {
        public CreateReservationModel()
        {
            //
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        [BindProperty]
        public Guest Guest { get; set; }

        public SelectList RoomList { get; set; }

        public void OnGet()
        {

        }

        public async Task OnPostAsync()
        { 
            
        }
    }
}
