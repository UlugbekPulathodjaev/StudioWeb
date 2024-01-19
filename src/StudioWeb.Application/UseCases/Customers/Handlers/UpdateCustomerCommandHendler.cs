using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudioWeb.Application.Abstruction;
using StudioWeb.Application.UseCases.Customers.Commands;
using StudioWeb.Domain.Entities;
using StudioWeb.TelegramBot.TelegramCommands;

namespace StudioWeb.Application.UseCases.Customers.Handlers
{
    public class UpdateCustomerCommandHendler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public UpdateCustomerCommandHendler(IConfiguration configuration, IApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<bool> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(x => x.Id == command.Id);

            if (customer == null)
                throw new Exception("Customer not found");

            customer.FullName = command.FullName;
            customer.PhoneNumber = command.PhoneNumber;
            customer.Budget = command.Budget;
            customer.EMail = command.EMail;
            customer.Comment = command.Comment;


            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                TelegramMessageBot telegram = new TelegramMessageBot(_configuration);

                await telegram.SendMessageToTelegramBotUpdate(command.Id, customer);
            }

            return result > 0;
        }
    }
}
