using MediatR;
using Microsoft.Extensions.Configuration;
using StudioWeb.Application.Abstruction;
using StudioWeb.Application.UseCases.Customers.Commands;
using StudioWeb.TelegramBot.TelegramCommands;

namespace StudioWeb.Application.UseCases.Customers.Handlers;

public class CreateCustomerCommandHendler : IRequestHandler<CreateCustomerCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public CreateCustomerCommandHendler(IConfiguration configuration, IApplicationDbContext context)
    {
        _context = context;
        _configuration= configuration;
    }

    public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Domain.Entities.Customer()
        {
            FullName = request.FullName,
            Status = request.Status,
            PhoneNumber = request.PhoneNumber,
            Budget = request.Budget,
            Comment = request.Comment,
            EMail = request.EMail
        };
        await _context.Customers.AddAsync(customer);
        int result = await _context.SaveChangesAsync(cancellationToken);

        TelegramMessageBot tg = new TelegramMessageBot(_configuration);

        await tg.SendMessageToTelegramBot(customer);

        return result > 0;
    }
}
