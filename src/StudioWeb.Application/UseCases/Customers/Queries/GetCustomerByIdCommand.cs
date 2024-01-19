using MediatR;

namespace StudioWeb.Application.UseCases.Customers.Queries
{
    public class GetCustomerByIdCommand : IRequest<StudioWeb.Domain.Entities.Customer>
    {
        public int Id { get; set; }
    }
}
