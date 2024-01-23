using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudioWeb.Application.UseCases.Customers.Commands;
using StudioWeb.Application.UseCases.Customers.Queries;

namespace StudioWeb.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
            
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateCustomerCommand command)
         {
            var result= await mediator.Send(command);
            return Ok(result);
        }
        
        [Authorize(Roles = "PPP")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var result = await mediator.Send(new GetAllCustomerCommand());
            return Ok(result);
        }

        [Authorize(Roles = "QQQ")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await mediator.Send(new GetCustomerByIdCommand{ Id = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateCustomerCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await mediator.Send(new DeleteCustomerCommand { Id = id });

            if (result)
            {
                return NoContent(); 
            }
            else
            {
                return NotFound();
            }
        }
    }
}
