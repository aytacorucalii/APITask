using employeePr.DAL.Repositories.Abstractions;
using EmployeePr.Core.Entities;
using EmployeePr.DAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeePr.DAL.Repositories.Implementations;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
