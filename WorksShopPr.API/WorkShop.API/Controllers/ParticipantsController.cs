using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorksShop.BL.DTOs.ParticipantsDTOs;
using WorksShop.BL.DTOs.WorkShopDTOs;
using WorksShop.BL.Services.Abstractions;
using WorksShop.Core.Entities;

namespace WorkShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantService _participantService;
        public ParticipantsController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> GetAll()
        {
            var result = await _participantService.GetAllAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetByIdAsync(int id)
        {
            var result = await _participantService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }
        [HttpPost]
        public async Task<ActionResult<Participant>> CreateAsync(ParticipantCreateDTO particiant)
        {
            return await _participantService.CreateAsync(particiant);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Participant>> DeleteAsync(int id)
        {
            await _participantService.DeleteAsync(id);
            return Ok();
        }
    }
}
