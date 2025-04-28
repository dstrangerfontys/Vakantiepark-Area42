using System.ComponentModel.DataAnnotations;
using Vakantiepark_Area42.Models.Entities.Base;

namespace Vakantiepark_Area42.Models.Entities
{
    public class Guest : EntityModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}
