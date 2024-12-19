using EmployeePr.Core.Entities.Base;
namespace EmployeePr.Core.Entities;
public class Employee:BaseAuditable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }

    public int DepartmentId { get; set; }
}
