using EmployeePr.Core.Entities.Base;

namespace EmployeePr.Core.Entities;

public class Department:BaseAuditable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Employee>? Employees { get; set; }
}
