using StudioWeb.Domain.Entities;

namespace StudioWeb.Application.Customers
{
    public interface ICustomerService
    {
        ValueTask<Customer> AddCustomerAsync(Customer customer);
        ValueTask<List<Customer>> GetCustomerAsync();
        ValueTask<Customer> DeleteCustomerAsync(int id);
        ValueTask<Customer> GetBranchFromFullNameAsync(string fullname);
    }
}
