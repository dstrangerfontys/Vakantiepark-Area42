using System.ComponentModel.DataAnnotations;

namespace VPA.Models
{
    /// <summary>
    /// Represents a guest in the system.
    /// </summary>
    public class Guest : EntityModel
    {
        /// <summary>
        /// The first name of the guest.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the guest.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// The email address of the guest.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// The phone number of the guest.
        /// </summary>
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
