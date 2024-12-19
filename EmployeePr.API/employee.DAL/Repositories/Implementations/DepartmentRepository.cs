using employeePr.DAL.Repositories.Abstractions;
using EmployeePr.Core.Entities;
using EmployeePr.DAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeePr.DAL.Repositories.Implementations;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
