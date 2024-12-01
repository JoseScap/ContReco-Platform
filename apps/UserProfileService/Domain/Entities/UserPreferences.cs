using Libs.SK.Domain.Entities;

namespace UPS.Domain.Entities;

public class UserPreferences : BaseEntity
{
    public List<string> Tags { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}
