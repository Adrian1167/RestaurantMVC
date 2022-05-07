using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Waiter
    {
        [Key]
        public int WaiterId { get; set; }
        [Required]
        public string? Name { get; set; }

        public string? Address { get; set; }

        public ICollection<Customer>? Customers { get; set; }
    }
}
