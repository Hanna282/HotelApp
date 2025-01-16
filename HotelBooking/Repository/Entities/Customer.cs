using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Repository.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(80)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(80)]
        public string Email { get; set; }

        [Required]
        [StringLength(60)]
        public string Phone { get; set; }

        public virtual List<Booking> Bookings { get; set; }
    }
}
