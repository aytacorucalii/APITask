namespace EmployeePr.Core.Entities.Base;

public class BaseAuditable:BaseEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
