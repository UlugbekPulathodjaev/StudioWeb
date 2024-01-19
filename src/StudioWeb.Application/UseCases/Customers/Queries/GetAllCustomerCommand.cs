using MediatR;

namespace StudioWeb.Application.UseCases.Customers.Queries
{
    public class GetAllCustomerCommand : IRequest<List<StudioWeb.Domain.Entities.Customer>>
    {
    }
}
