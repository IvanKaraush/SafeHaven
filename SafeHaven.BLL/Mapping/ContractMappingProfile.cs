using AutoMapper;
using SafeHaven.BLL.Dto;
using SafeHaven.DAL.Entities;

namespace SafeHaven.BLL.Mapping;

public class ContractMappingProfile : Profile
{
    public ContractMappingProfile()
    {
        CreateMap<Contract, ContractDto>()
            .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments.ToList()))
            .ForMember(dest => dest.InsuranceCases, opt => opt.MapFrom(src => src.InsuranceCases.ToList()))
            .ForMember(dest => dest.InsuranceType, opt => opt.MapFrom(src => src.InsuranceType))
            .ReverseMap();
    }
}