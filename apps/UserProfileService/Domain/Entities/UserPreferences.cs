using Libs.SK.Domain.Entities;

namespace UPS.Domain.Entities;

public class UserPreferences : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public Guid PreferenceId { get; set; }
    public virtual Preference Preference { get; set; }
}
