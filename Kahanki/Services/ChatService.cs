using Kahanki.Data;
using Kahanki.Models;
using Kahanki.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Kahanki.Services;

public class ChatService : IChatService
{
    private readonly IMatchService _matchService;
    private readonly ApplicationDbContext _db;

    public ChatService(IMatchService matchService, ApplicationDbContext db)
    {
        _matchService = matchService;
        _db = db;
    }

    public List<UserShortProfile> GetChatListByUserId(string userId)
    {
        var matches = _matchService.GetAllCouplesByUserId(userId);

        return matches
            .Select(match => _db.ApplicationUsers.Single(c => c.Id == match))
            .Select(user => new UserShortProfile
            {
                Id = user.Id, 
                Name = user.NormalizedUserName
            })
            .ToList();
    }

    public Chat GetChat(string userId, string targetUserId)
    {
        var chat = _db.Chats
            .Include(c => c.Users)
            .Include(c => c.Messages)
            .SingleOrDefault(c => c.Users.Select(c => c.Id).Contains(userId) &&
                                  c.Users.Select(c => c.Id).Contains(targetUserId));

        if (chat is null)
        {
            var user = _db.ApplicationUsers.Single(c => c.Id == userId);
            var targetUser = _db.ApplicationUsers.Single(c => c.Id == targetUserId);

            _db.Chats.Add(new Chat
            {
                Messages = new List<Message>(),
                Users = new List<ApplicationUser>
                {
                    user,
                    targetUser
                }
            });

            _db.SaveChanges();

            chat = _db.Chats
                .Include(c => c.Users)
                .Include(c => c.Messages)
                .Single(c => c.Users.Select(c => c.Id).Contains(userId) && 
                             c.Users.Select(c => c.Id).Contains(targetUserId));
        }

        return chat;
    }
}