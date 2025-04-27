using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vakantiepark_Area42.Data;
using Vakantiepark_Area42.Models;

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
        public Reservation Reservation { get; set; }

        [BindProperty]
        public Guest Guest { get; set; }

        public SelectList RoomList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var today = DateTime.Today;

            var reservations = await _context.Reservations
                .Include(r => r.Room)
                .ToListAsync();

            foreach (var reservation in reservations)
            {
                if (reservation.CheckOutDate < today)
                {
                    var room = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == reservation.RoomId);
                    if (room != null && !room.IsAvailable)
                    {
                        room.IsAvailable = true;
                    }
                }
            }

            await _context.SaveChangesAsync();

            RoomList = new SelectList(await _context.Rooms.ToListAsync(), "RoomId", "RoomNumber");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Reservation.CheckInDate < DateTime.Today)
            {
                ModelState.AddModelError("Reservation.CheckInDate", "Incheck datum kan niet in het verleden zijn.");
            }

            if (Reservation.CheckOutDate <= Reservation.CheckInDate)
            {
                ModelState.AddModelError("Reservation.CheckOutDate", "Uitcheck datum moet na de Incheck datum zijn.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == Reservation.RoomId);

            if (room != null)
            {
                room.IsAvailable = false;

                _context.Reservations.Add(Reservation);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            ModelState.AddModelError(string.Empty, "Kamer niet gevonden.");
            return Page();
        }

    }
}
