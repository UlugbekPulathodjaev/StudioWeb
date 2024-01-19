using MediatR;
using Microsoft.EntityFrameworkCore;
using StudioWeb.Application.Abstruction;
using StudioWeb.Application.UseCases.Customers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioWeb.Application.UseCases.Customers.Handlers
{
    public class GetCustomerByIdCommandHendler : IRequestHandler<GetCustomerByIdCommand, Domain.Entities.Customer>
    {
        private readonly IApplicationDbContext _context;
        public GetCustomerByIdCommandHendler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Entities.Customer> Handle(GetCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null)
            {
                throw new Exception("Something went wrong");
            }
            return result;
        }
    }
}
