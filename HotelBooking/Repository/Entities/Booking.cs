using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Repository.Entities
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime BookingDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public int NumbOfExtraBeds { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime PaymentDueDate { get; set; }

        [Required]
        public bool IsPaid { get; set; }

        [Required]
        public int NumbOfGuests { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Room Room { get; set; }

        public override string ToString()
        {
            return $"Bokningsnr: {BookingId}.   " +
                   $"Datum: {StartDate.ToString("yyyy-MM-dd")} - {EndDate.Date.ToString("yyyy-MM-dd")}.   " +
                   $"Kund: {Customer.CustomerName}.   " +
                   $"Rum: {Room.RoomId},  {Room.RoomName},   " +
                   $"{(IsPaid ? "Betald" : "Obetald")}";
        }
    }
}
