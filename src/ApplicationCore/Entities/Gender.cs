using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;

public class Gender:BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public Gender(string name)
    {
        Name = name;
    }
}
