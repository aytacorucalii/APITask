using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePr.BL.DTOs.EmployeeDTOs;

public class CreateEmployeeDTO
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public int DepartmentId {  get; set; }
}
