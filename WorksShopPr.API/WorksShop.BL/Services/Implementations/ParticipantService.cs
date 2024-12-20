using WorksShop.BL.DTOs.ParticipantsDTOs;
using WorksShop.BL.Services.Abstractions;
using WorksShop.Core.Entities;
using WorksShop.DAL.Repositories.Abstractions;
using WorksShop.DAL.Repositories.Implementations;

namespace WorksShop.BL.Services.Implementations;

public class ParticipantService : IParticipantService
{ 
    private readonly IParticipantRepository _participantRepository;
    public ParticipantService(IParticipantRepository participantRepository)
    {
        _participantRepository=participantRepository;
    }
    public async Task<IEnumerable<Participant>> GetAllAsync()
    {
        return await _participantRepository.GetAllAsync();
    }


    public async Task<Participant> GetByIdAsync(int id)
    {
      return await _participantRepository.GetByIdAsync(id);
    }

    public async Task<Participant> CreateAsync(ParticipantCreateDTO participantCreateDTO)
    {
        Participant participant = new Participant()
        {
            Name=participantCreateDTO.Name,
            Email=participantCreateDTO.Email,
            Phone= participantCreateDTO.Phone,
            WorkShopId=participantCreateDTO.WorkShopId
        };
        await _participantRepository.CreateAsync(participant);
        await _participantRepository.SaveChangesAsync();
        return participant;
    }

    public async Task DeleteAsync(int id)
    {
        await _participantRepository.DeleteAsync(id);
    }
 
}
