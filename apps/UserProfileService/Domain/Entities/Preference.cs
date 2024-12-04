using Libs.SK.Domain.Entities;

namespace UPS.Domain.Entities;

public class Preference : BaseEntity
{
    public required string Tag { get; set; }
    public IList<User> Users { get; set; } = [];

    public Preference() { }

    public Preference(string tag)
    {
        Tag = tag;
    }
}
