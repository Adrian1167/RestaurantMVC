using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public Customer? Customer  { get; set; }
        [Required]
        public string? Date { get; set; }
        [Required]
        public int NOofPersons { get; set; }
    }
}
