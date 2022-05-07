using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        [Required]
        public string? Speciality { get; set; }

        public ICollection<FoodItem>? FoodItems { get; set; }
    }
}
