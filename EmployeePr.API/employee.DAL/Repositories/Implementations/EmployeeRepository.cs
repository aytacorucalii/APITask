using employeePr.DAL.Repositories.Abstractions;
using EmployeePr.Core.Entities;
using EmployeePr.DAL.DAL;

namespace employeePr.DAL.Repositories.Implementations;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
