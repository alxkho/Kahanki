namespace Kahanki.Models;

public abstract class BaseEntity : IEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }
}