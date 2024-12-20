using WorksShop.BL.DTOs.ParticipantsDTOs;
using WorksShop.BL.DTOs.WorkShopDTOs;
using WorksShop.Core.Entities;

namespace WorksShop.BL.Services.Abstractions;

public interface IParticipantService
{
    Task<IEnumerable<Participant>> GetAllAsync();
    Task<Participant> GetByIdAsync(int id);
    Task<Participant> CreateAsync(ParticipantCreateDTO participantCreateDTO);
    Task DeleteAsync(int id);

}
