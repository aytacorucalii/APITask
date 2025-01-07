using AutoMapper;
using HospitalManagement.BL.DTOs.InsuranceDTOs;
using HospitalManagement.Core.Entities;

namespace HospitalManagement.BL.Profiles;

public class InsuranceProfile :Profile
{
    public InsuranceProfile()
    {
        CreateMap<InsuranceCreateDTO, Insurance>().ReverseMap();
    }
}
