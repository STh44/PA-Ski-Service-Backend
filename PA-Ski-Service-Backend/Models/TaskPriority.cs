using System.ComponentModel.DataAnnotations;
using SkiServiceBackend.Models;

namespace SkiServiceBackend.Models
{
    public class TaskPriority
    {
        [Key]
        public int PriorityID { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int DaysToCompletion { get; set; }
    }
}
