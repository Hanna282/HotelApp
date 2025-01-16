using HotelBooking.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository.Repos
{
    public class CustomerRepo
    {
        private readonly DataContext _context;

        public CustomerRepo()
        {
            _context = new DataContext();
        }

        public void InsertCustomer(Customer customer)
        {
            if (customer != null)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
        }

        public void UpdateCustomer(Customer customerNew)
        {
            Customer? customerOrg = _context.Customers
                                    .SingleOrDefault(c => c.CustomerId == customerNew.CustomerId);
            if (customerOrg != null)
            {
                customerOrg.CustomerName = customerNew.CustomerName;
                customerOrg.Email = customerNew.Email;
                customerOrg.Phone = customerNew.Phone;
                _context.SaveChanges();
            }
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = GetCustomerById(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public bool hasBookings(int id)
        {
            return _context.Bookings.Any(b => b.Customer.CustomerId == id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.SingleOrDefault(c => c.CustomerId == id);
        }

        public int GetCustomerId(string email)
        {
            var customer = _context.Customers
                                   .AsNoTracking()
                                   .SingleOrDefault(c => c.Email == email);

            if (customer != null)
                return customer.CustomerId;
            else
                return 0; 
        }
    }
}
