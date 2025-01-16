using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Repository.Entities
{
    public class RoomSize
    {
        [Key]
        public int RoomSizeId { get; set; }

        [Required]
        [StringLength(30)]
        public string RoomSizeName { get; set; }

        [Required]
        public decimal PricePerNight { get; set; }

        [Required]
        public int MaxExtraBeds { get; set; }

        public virtual List<Room> Rooms { get; set; }
    }
}
