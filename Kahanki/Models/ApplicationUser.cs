using Microsoft.AspNetCore.Identity;

namespace Kahanki.Models
{
    public class ApplicationUser : IdentityUser, IEntity
    {
        public virtual UserSettings UserSettings { get; set; } = new UserSettings();

        public virtual List<UserMatchAction> OwnMatchActions { get; set; } = new List<UserMatchAction>();
        public virtual List<UserMatchAction> TargetMatchActions { get; set; } = new List<UserMatchAction>();
        public virtual List<Chat> Chats { get; set; } = new List<Chat>();
    }
}