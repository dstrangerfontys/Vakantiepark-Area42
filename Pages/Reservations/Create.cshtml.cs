using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vakantiepark_Area42.Data;

namespace Vakantiepark_Area42.Pages.Reservations
{

    public class CreateModel : PageModel
    {
        private readonly HotelContext _context;

        public CreateModel(HotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Reservation Reservation { get; set; }

        public SelectList GuestList { get; set; }
        public SelectList RoomList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            GuestList = new SelectList(await _context.Guests.ToListAsync(), "Id", "FirstName");
            RoomList = new SelectList(await _context.Rooms.ToListAsync(), "Id", "RoomNumber");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var room = await _context.Rooms.FindAsync(Reservation.RoomId);
            var days = (Reservation.CheckOutDate - Reservation.CheckInDate).Days;
            Reservation.TotalPrice = days * room.PricePerNight;

            _context.Reservations.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Reservations/Create");
        }
    }

}
