using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudioWeb.Application.Abstruction;
using StudioWeb.Application.UseCases.Customers.Commands;
using StudioWeb.Domain.Entities;
using StudioWeb.TelegramBot.TelegramCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace StudioWeb.Application.UseCases.Customers.Handlers
{
    public class DeleteCustomerCommandHendler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public DeleteCustomerCommandHendler(IConfiguration configuration,IApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<bool> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == command.Id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            _context.Customers.Remove(customer);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                TelegramMessageBot telegram = new TelegramMessageBot(_configuration);

                await telegram.SendMessageToTelegramBotForDelete(command.Id, customer);
            }

            return result > 0;
        }


    }
}
