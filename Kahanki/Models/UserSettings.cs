namespace Kahanki.Models
{
    public class UserSettings : BaseEntity
    {
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string RealName { get; set; } = "";

        public int Age { get; set; }

        public int Sex { get; set; }

        public string Description { get; set; } = "";

        public string Job { get; set; } = "";

        public string Education { get; set; } = "";

        public int Preferences { get; set; }

        public int AgeFrom { get; set; }

        public int AgeTo { get; set; }
    }
}
