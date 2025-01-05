namespace Final.Core.Entities.Base;

public class BaseAuditable: BaseEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

}
