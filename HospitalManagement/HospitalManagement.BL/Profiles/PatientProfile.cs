using AutoMapper;
using HospitalManagement.BL.DTOs.PatientDTOs;
using HospitalManagement.Core.Entities;

namespace HospitalManagement.BL.Profiles;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<PatientCreateDTO, Patient>().ReverseMap();
    }
}
