using employeePr.DAL.Repositories.Abstractions;
using EmployeePr.Core.Entities;
using EmployeePr.DAL.DAL;

namespace employeePr.DAL.Repositories.Implementations;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
