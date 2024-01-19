using Microsoft.Extensions.Configuration;
using StudioWeb.Domain.DTOs;
using StudioWeb.Domain.Entities;
using System.Threading.Tasks;
using Telegram.Bot;

namespace StudioWeb.TelegramBot.TelegramCommands
{
    public class TelegramMessageBot
    {
        private readonly ITelegramBotClient _botClient;

        public TelegramMessageBot(IConfiguration config)
        {
            _botClient = new TelegramBotClient(config["TelegramBotAPIKey"]);
        }

        public async ValueTask SendMessageToTelegramBot(Customer customer)
        {
            var text = $"ID: {customer.Id}\nFull Name: {customer.FullName}\nPhone Number: {customer.PhoneNumber}\nBudget: {customer.Budget}\nEmail: {customer.EMail}\nComment: {customer.Comment}\nStatus: {customer.Status}";

            await _botClient.SendTextMessageAsync(
                chatId: 1871253641,
                text: text);
        }

        public async ValueTask SendMessageToTelegramBotUpdate(int id, Customer customer)
        {
            var text = $"Customer with ID: {id} was changed\nFull Name: {customer.FullName}\nPhone Number: {customer.PhoneNumber}\nBudget: {customer.Budget}\nEmail: {customer.EMail}\nComment: {customer.Comment}\nStatus: {customer.Status}";

            await _botClient.SendTextMessageAsync(
                chatId: 1871253641,
                text: text);
        }

        public async ValueTask SendMessageToTelegramBotForDelete(int id, Customer customer)
        {
            var text = $"Customer with id: {id} was deleted\nFull Name: {customer.FullName}\nPhone Number: {customer.PhoneNumber}\nBudget: {customer.Budget}\nEmail: {customer.EMail}\nComment: {customer.Comment}\nStatus: {customer.Status}";

            await _botClient.SendTextMessageAsync(
                chatId: 1871253641,
                text: text);
        }
    }
}
