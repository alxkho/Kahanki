using Kahanki.Data;
using Kahanki.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace Kahanki.Services;

public class MatchService : IMatchService
{
    private readonly ApplicationDbContext _db;

    public MatchService(ApplicationDbContext db)
    {
        _db = db;
    }

    public List<string> GetAllCouplesByUserId(string userId)
    {
        var actionUsers = _db.UserMatchActions
            .Where(r => r.ActedUserId == userId && (r.ActionId == (int)MatchAction.Like || r.ActionId == (int)MatchAction.SuperLike))
            .Select(r => r.TargetUserId)
            .ToList();

        var targetUsers = _db.UserMatchActions
            .Where(r => r.TargetUserId == userId && (r.ActionId == (int)MatchAction.Like || r.ActionId == (int)MatchAction.SuperLike))
            .Select(r => r.ActedUserId)
            .ToList();

        return actionUsers.Intersect(targetUsers).ToList();
    }

    public bool CheckIsMatchTakePlace(UserMatchAction matchAction)
    {
        if (matchAction.ActionId != (int)MatchAction.Dislike)
        {
            return _db.UserMatchActions.SingleOrDefault(r => r.ActedUserId == matchAction.TargetUserId &&
                                                             r.TargetUserId == matchAction.ActedUserId &&
                                                             r.ActionId != (int)MatchAction.Dislike) != null;
        }

        return false;
    }

    public void DisMatch(string currentUser, string targetUser)
    {

        var match = _db.UserMatchActions.Single(r => r.ActedUserId == currentUser && r.TargetUserId == targetUser);
        match.ActionId = (int)MatchAction.Dislike;
        _db.UserMatchActions.Update(match);
        _db.SaveChanges();
    }
}