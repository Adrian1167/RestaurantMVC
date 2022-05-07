using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }
    }
}
