using WorksShop.Core.Entities;

namespace WorksShop.BL.Services.Abstractions;

public interface IParticipantService
{
    Task<IEnumerable<Participant>> GetAllAsync();
    Task<Participant> GetByIdAsync(int id);

}
