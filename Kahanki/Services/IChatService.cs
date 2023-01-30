using Kahanki.Models;
using Kahanki.ViewModels;

namespace Kahanki.Services
{
    public interface IChatService
    {
        List<UserShortProfile> GetChatListByUserId(string userId);

        Chat GetChat(string userId, string targetUserId);
    }
}
