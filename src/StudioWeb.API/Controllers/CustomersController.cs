using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioWeb.Application.Abstruction;
using StudioWeb.Application.Customers;
using StudioWeb.Domain.Entities;

namespace StudioWeb.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
            => _customerService = customerService;
        
        public async ValueTask<Customer> AddCustomerAsync(Customer customer)
        {
            var newCustomer = await _customerService.AddCustomerAsync(customer);

            return newCustomer;
        }

        public async ValueTask<List<Customer>> GetCustomerAsync()
            => throw new NotImplementedException();


        public async ValueTask<Customer> GetBranchFromFullNameAsync(string fullname)
            => throw new NotImplementedException();


        public async ValueTask<Customer> DeleteCustomerAsync(int id)
            => throw new NotImplementedException();
    }
}
