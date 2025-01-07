using HospitalManagement.Core.Entities;
using HospitalManagement.DAL.DAL;
using HospitalManagement.DAL.Repositories.Abstractions;

namespace HospitalManagement.DAL.Repositories.Implementations;

public class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    public PatientRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
