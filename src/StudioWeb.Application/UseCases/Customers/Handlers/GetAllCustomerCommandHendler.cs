using MediatR;
using Microsoft.EntityFrameworkCore;
using StudioWeb.Application.Abstruction;
using StudioWeb.Application.UseCases.Customers.Queries;
using Microsoft.Extensions.Caching.Memory;

namespace StudioWeb.Application.UseCases.Customers.Handlers
{
    public class GetAllCustomerCommandHandler : IRequestHandler<GetAllCustomerCommand, List<Domain.Entities.Customer>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public GetAllCustomerCommandHandler(IApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<List<Domain.Entities.Customer>> Handle(GetAllCustomerCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = "AllCustomers";

            if (_cache.TryGetValue(cacheKey, out List<Domain.Entities.Customer> cachedCustomers))
            {
                return cachedCustomers;
            }

            var customers = await _context.Customers.ToListAsync(cancellationToken);

            _cache.Set(cacheKey, customers, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) 
            });

            return customers;
        }
    }
}
