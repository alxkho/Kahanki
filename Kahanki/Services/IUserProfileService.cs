using Kahanki.ViewModels;

namespace Kahanki.Services;

public interface IUserProfileService
{
    UserProfile? GetNextUserProfileByUserId(string userId);

    void SubmitUserAction(string currentUserId, string targetUserId, int actionId);
}