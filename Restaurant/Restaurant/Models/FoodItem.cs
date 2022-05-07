using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class FoodItem
    {
        [Key]
        public int FoodItemId { get; set; }
        [Required]
        public string? Name { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }



    }
}
