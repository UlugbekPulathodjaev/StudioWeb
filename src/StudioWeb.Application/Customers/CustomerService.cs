using Microsoft.EntityFrameworkCore;
using StudioWeb.Application.Abstruction;
using StudioWeb.Domain.Entities;

namespace StudioWeb.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IApplicationDbContext _context;

        public CustomerService(IApplicationDbContext context)
            => _context = context;

        public async ValueTask<Customer> AddCustomerAsync(Customer customer)
        {
            var entry = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<List<Customer>> GetCustomerAsync()
        {
            var customers = await _context.Customers.ToListAsync();

            return customers;
        }


        public async ValueTask<Customer> GetBranchFromFullNameAsync(string fullname)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.FullName == fullname);

            if (customer == null)
                throw new Exception("Customer not found");

            return customer;
        }


        public async ValueTask<Customer> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer != null)
            {
                throw new Exception("Customer not found");
            }

            var entry = _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
