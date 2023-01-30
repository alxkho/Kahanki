using Kahanki.Data;
using Microsoft.AspNetCore.SignalR;

namespace Kahanki.Hubs
{
    public class ChatHub : Hub  
    {
        private readonly ApplicationDbContext _db;

        public ChatHub(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task SendMessage(string chatId, string user, string message)
        {
            _db.Messages.Add(new Models.Message
            {
                ChatId = chatId,
                Content = message,
                SenderId = user,
                Created = DateTime.Now,
            });
            _db.SaveChanges();

            await Clients.All.SendAsync("messageReceived", chatId, user, message);
        }
    }
}
