using HotelBooking.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository.Repos
{
    public class BookingRepo
    {
        private readonly DataContext _context;

        public BookingRepo()
        {
            _context = new DataContext();
        }

        public List<Booking> GetAllBookings()
        {
            return _context.Bookings
                           .Include(b => b.Customer)
                           .Include(b => b.Room)
                           .ThenInclude(r => r.RoomSize)
                           .AsNoTracking()
                           .ToList();
        }

        public decimal GetBookingAmount(decimal pricePerNight, DateTime startDate, DateTime endDate)
        {
            TimeSpan period = endDate - startDate;
            int numbOfDays = period.Days;
            return pricePerNight * numbOfDays;
        }

        public bool RegisterPayment(Booking booking)
        {
            var existingBooking = _context.Bookings.SingleOrDefault(b => b.BookingId == booking.BookingId);

            if (existingBooking == null)
                return false;
            else if (existingBooking.IsPaid)
                return false;
            else
            {
                existingBooking.IsPaid = true;
                _context.SaveChanges();
                return true;
            }
        }

        public void CheckAllBookings()
        {
            var unpaidBookings = GetAllBookings().Where(b => b.IsPaid == false);
            foreach (var booking in unpaidBookings)
            {
                CheckAndCancelBooking(booking.BookingId);
            }
        }

        private void CheckAndCancelBooking(int id)
        {
            var booking = _context.Bookings.SingleOrDefault(b => b.BookingId == id);

            if (booking != null && !booking.IsPaid && (DateTime.Today - booking.BookingDate).Days >= 10)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }

        public void InsertBooking(Booking booking, Customer selectedCustomer, Room selectedRoom)
        {
            var existingCustomer = _context.Customers
                                            .FirstOrDefault(c => c.CustomerId == selectedCustomer.CustomerId);

            if (existingCustomer != null)
                booking.Customer = existingCustomer;
            else
                booking.Customer = selectedCustomer;

            var existingRoom = _context.Rooms
                                       .FirstOrDefault(r => r.RoomId == selectedRoom.RoomId);
            if (existingRoom != null)
            {
                //Visar att rummet inte har ändrats
                _context.Entry(existingRoom).State = EntityState.Unchanged;
                booking.Room = existingRoom;
            }
            else
                booking.Room = selectedRoom;

            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void UpdateBooking(Booking updatedBooking)
        {
            var existingBooking = _context.Bookings
                                          .Include(b => b.Room)
                                          .ThenInclude(r => r.RoomSize)
                                          .FirstOrDefault(b => b.BookingId == updatedBooking.BookingId);
            if (existingBooking == null)
                return;
            else
            {
                _context.Entry(existingBooking).State = EntityState.Detached;
                _context.Entry(existingBooking.Room).State = EntityState.Detached;

                existingBooking.StartDate = updatedBooking.StartDate;
                existingBooking.EndDate = updatedBooking.EndDate;
                existingBooking.NumbOfGuests = updatedBooking.NumbOfGuests;
                existingBooking.Amount = updatedBooking.Amount;
                existingBooking.Room = updatedBooking.Room;

                _context.Entry(updatedBooking.Room).State = EntityState.Modified;
                _context.Entry(existingBooking).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void DeleteBooking(int id)
        {
            var existingBooking = _context.Bookings.SingleOrDefault(b => b.BookingId == id);

            if (existingBooking == null)
                return;
            else
            {
                if (_context.Entry(existingBooking).State == EntityState.Detached)
                    _context.Bookings.Attach(existingBooking); 

                _context.Bookings.Remove(existingBooking);
                _context.SaveChanges();
            }
        }

        public void UpdateExtraBedInBooking(Booking booking, int change)
        {
            var existingBooking = _context.Bookings
                                  .Include(b => b.Customer)
                                  .Include(b => b.Room)
                                  .ThenInclude(r => r.RoomSize)
                                  .FirstOrDefault(b => b.BookingId == booking.BookingId);

            if (existingBooking == null)
                return;
            else
            {   
                existingBooking.NumbOfExtraBeds += change;
                _context.Entry(existingBooking).Property(b => b.NumbOfExtraBeds).IsModified = true;
                _context.SaveChanges();
            }
        }
    }
}
