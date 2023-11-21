using System.ComponentModel.DataAnnotations;

namespace SkiServiceBackend.Models
{
    public class RegisteredUser
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public string Priority { get; internal set; }
        public string Service { get; internal set; }
        public DateTime PickupDate { get; internal set; }
    }
}
