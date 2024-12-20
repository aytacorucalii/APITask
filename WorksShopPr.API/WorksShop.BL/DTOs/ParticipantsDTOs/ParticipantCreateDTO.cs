namespace WorksShop.BL.DTOs.ParticipantsDTOs;

public class ParticipantCreateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public int WorkShopId { get; set; }
}
