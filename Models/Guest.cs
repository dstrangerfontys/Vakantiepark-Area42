﻿namespace Vakantiepark_Area42.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }

}
