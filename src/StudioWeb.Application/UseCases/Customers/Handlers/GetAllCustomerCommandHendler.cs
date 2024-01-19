using MediatR;
using Microsoft.EntityFrameworkCore;
using StudioWeb.Application.Abstruction;
using StudioWeb.Application.UseCases.Customers.Queries;

namespace StudioWeb.Application.UseCases.Customers.Handlers
{
    public class GetAllCustomerCommandHandler : IRequestHandler<GetAllCustomerCommand, List<Domain.Entities.Customer>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllCustomerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Domain.Entities.Customer>> Handle(GetAllCustomerCommand request, CancellationToken cancellationToken)
        {
            var customers = await _context.Customers.ToListAsync(cancellationToken);
            return customers;
        }
    }
}