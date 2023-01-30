using Kahanki.Models;

namespace Kahanki.Services
{
    public interface IUserSettingsService
    {
        UserSettings GetUserSettingsByUserId(string userId);
    }
}
