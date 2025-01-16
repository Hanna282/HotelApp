using HotelBooking.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace HotelBooking.Repository
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = ConfigurationManager.ConnectionStrings["HotelBookingDB"].ConnectionString;
            optionsBuilder.UseSqlServer(connString);
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomSize> RoomSizes { get; set; }
    }
}
