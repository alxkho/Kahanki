using Kahanki.Data;
using Kahanki.Models;

namespace Kahanki.Services;

public class UserSettingsService : IUserSettingsService
{
    private readonly ApplicationDbContext _db;

    public UserSettingsService(ApplicationDbContext db)
    {
        _db = db;
    }

    public UserSettings GetUserSettingsByUserId(string userId)
    {
        var userSettings = _db.UserSettings.SingleOrDefault(c => c.ApplicationUserId == userId);

        if (userSettings != null)
        {
            return userSettings;
        }


        _db.UserSettings.Add(new UserSettings
        {
            ApplicationUserId = userId
        });
        _db.SaveChanges();

        return GetUserSettingsByUserId(userId);
    }
}