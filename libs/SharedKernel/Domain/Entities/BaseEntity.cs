namespace Libs.SK.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public BaseEntity()
    {
    }

    public BaseEntity(Guid id, DateTime? createdDate, DateTime? modifiedDate)
    {
        Id = id;
        if (createdDate is not null) CreatedDate = createdDate.Value;
        if (modifiedDate is not null) ModifiedDate = modifiedDate.Value;
    }
}
