using WorksShop.Core.Entities;
using WorksShop.DAL.DAL;
using WorksShop.DAL.Repositories.Abstractions;

namespace WorksShop.DAL.Repositories.Implementations;

public class ParticipantRepository : GenericRepository<Participant>, IParticipantRepository
{
    public ParticipantRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
