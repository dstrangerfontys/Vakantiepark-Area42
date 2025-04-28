using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vakantiepark_Area42.Data;
using Vakantiepark_Area42.Models.Entities;

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
            DateTime today = DateTime.Today;

            List<Reservation> reservations = await _context.Reservation
                .Include(r => r.Room)
                .ToListAsync();

            foreach (Reservation reservation in reservations)
            {
                if (reservation.CheckOutDate < today)
                {
                    Room room = await _context.Room.FirstOrDefaultAsync(r => r.Id == reservation.RoomId);
                    if (room != null && !room.IsAvailable)
                    {
                        room.IsAvailable = true;
                    }
                }
            }

            await _context.SaveChangesAsync();

            RoomList = new SelectList(await _context.Room.ToListAsync(), "RoomId", "RoomNumber");

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

            Room room = await _context.Room.FirstOrDefaultAsync(r => r.Id == Reservation.RoomId);

            if (room != null)
            {
                room.IsAvailable = false;

                _context.Reservation.Add(Reservation);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            ModelState.AddModelError(string.Empty, "Kamer niet gevonden.");
            return Page();
        }

    }
}
