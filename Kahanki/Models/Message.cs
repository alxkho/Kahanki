namespace Kahanki.Models
{
    public class Message : BaseEntity
    {
        public string SenderId { get; set; }

        public string ChatId { get; set; }

        public Chat Chat { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }
    }
}
