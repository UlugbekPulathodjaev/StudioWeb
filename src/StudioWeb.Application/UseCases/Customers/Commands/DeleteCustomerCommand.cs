using MediatR;

namespace StudioWeb.Application.UseCases.Customers.Commands
{
    public class DeleteCustomerCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
