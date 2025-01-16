using HotelBooking.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository.Repos
{
    public class RoomRepo
    {
        private readonly DataContext _context;

        public RoomRepo()
        {
            _context = new DataContext();
        }

        private List<Room> GetAllRooms()
        {
            return _context
                        .Rooms
                        .AsNoTracking()
                        .Include(r => r.RoomSize)
                        .Include(r => r.Bookings)
                        .ToList();
        }

        public List<Room> SearchAvailableRooms(DateTime startDate, DateTime endDate, int numbOfGuests)
        {
            var allRoomsOfSize = GetAllRooms()
                                .Where(r => (numbOfGuests == 1 && r.NumberOfBeds >= 1) ||
                                            (numbOfGuests > 1 && r.NumberOfBeds >= 2))
                                .ToList();

            var availableRooms = allRoomsOfSize
                                .Where(r => r.Bookings == null || !r.Bookings.Any
                                      (b => (startDate >= b.StartDate && startDate <= b.EndDate) ||
                                            (endDate >= b.StartDate && endDate <= b.EndDate) ||
                                            (startDate <= b.StartDate && endDate >= b.EndDate)))
                                .ToList();
            return availableRooms;
        }
    }
}
