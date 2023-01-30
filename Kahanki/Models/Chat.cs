namespace Kahanki.Models;

public class Chat : BaseEntity
{
    public List<Message> Messages { get; set; }

    public List<ApplicationUser> Users { get; set; }
}