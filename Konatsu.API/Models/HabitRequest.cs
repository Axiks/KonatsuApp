using System.ComponentModel.DataAnnotations;

namespace Konatsu.API.Models
{
    public class HabitRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
