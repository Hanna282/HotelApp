using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Repository.Entities
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        [StringLength(30)]
        public string RoomName { get; set; }

        [Required]
        public int NumberOfBeds { get; set; }

        public virtual List<Booking> Bookings { get; set; }
        public virtual RoomSize RoomSize { get; set; }

        public override string ToString()
        {
            return $"Nr: {RoomId},  {RoomName}";
        }
    }
}
