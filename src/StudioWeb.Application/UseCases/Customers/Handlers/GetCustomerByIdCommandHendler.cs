using MediatR;
using Microsoft.EntityFrameworkCore;
using StudioWeb.Application.Abstruction;
using StudioWeb.Application.UseCases.Customers.Queries;
using Microsoft.Extensions.Caching.Memory;

namespace StudioWeb.Application.UseCases.Customers.Handlers
{
    public class GetCustomerByIdCommandHandler : IRequestHandler<GetCustomerByIdCommand, Domain.Entities.Customer>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public GetCustomerByIdCommandHandler(IApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<Domain.Entities.Customer> Handle(GetCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = $"Customer_{request.Id}";

            if (_cache.TryGetValue(cacheKey, out Domain.Entities.Customer cachedCustomer))
            {
                return cachedCustomer;
            }

            var result = await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (result == null)
            {
                throw new Exception("Something went wrong");
            }

            _cache.Set(cacheKey, result, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) 
            });

            return result;
        }
    }
}
