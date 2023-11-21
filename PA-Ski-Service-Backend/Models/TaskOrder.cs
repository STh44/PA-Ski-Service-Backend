using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkiServiceBackend.Models;

namespace SkiServiceBackend.Models
{
    public class TaskOrder
    {
        [Key]
        public int OrderID { get; set; }

        // Foreign key for Customer
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        // Foreign key for Priority
        [ForeignKey("Priority")]
        public int PriorityID { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime PickupDate { get; set; }
    }
}
