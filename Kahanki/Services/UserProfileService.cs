using Kahanki.Data;
using Kahanki.Models;
using Kahanki.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Kahanki.Services;

public class UserProfileService : IUserProfileService
{
    private readonly ApplicationDbContext _db;

    public UserProfileService(ApplicationDbContext db)
    {
        _db = db;
    }

    public UserProfile? GetNextUserProfileByUserId(string userId)
    {
        var user = _db.ApplicationUsers
            .Include(c => c.UserSettings)
            .Include(c => c.OwnMatchActions)
            .Single(c => c.Id == userId);

        var alreadyActedUser = user.OwnMatchActions
            .Select(c => c.TargetUserId)
            .ToList();

        var candidates = _db.ApplicationUsers
            .Include(c => c.UserSettings)
            .Where(c => c.UserSettings.Preferences == user.UserSettings.Sex &&
                        c.UserSettings.AgeFrom <= user.UserSettings.Age &&
                        c.UserSettings.AgeTo >= user.UserSettings.Age &&
                        c.UserSettings.Sex == user.UserSettings.Preferences &&
                        !alreadyActedUser.Contains(c.Id))
            .ToList();


        var target = candidates.Skip(new Random().Next(0, candidates.Count)).FirstOrDefault();

        if (target is null)
        {
            return null;
        }

        return new UserProfile
        {
            Id = target.Id,
            Age = target.UserSettings.Age,
            Description = target.UserSettings.Description,
            Job = target.UserSettings.Job,
            Education = target.UserSettings.Education,
            Name = target.UserSettings.RealName
        };
    }

    public void SubmitUserAction(string currentUserId, string targetUserId, int actionId)
    {
        var actor = _db.ApplicationUsers
            .Include(c => c.UserSettings)
            .Single(c => c.Id == currentUserId);

        var target = _db.ApplicationUsers
            .Include(c => c.UserSettings)
            .Single(c => c.Id == targetUserId);

        var action = new UserMatchAction
        {
            //ActedUserId = currentUserId,
            //TargetUserId = targetUserId,
            ActionId = actionId,
            ActedUser = actor,
            TargetUser = target
        };

        _db.UserMatchActions.Add(action);
        _db.SaveChanges();
    }
}