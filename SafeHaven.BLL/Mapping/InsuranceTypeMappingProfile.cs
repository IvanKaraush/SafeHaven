using AutoMapper;
using SafeHaven.BLL.Dto;
using SafeHaven.DAL.Entities;

namespace SafeHaven.BLL.Mapping;

public class InsuranceTypeMappingProfile : Profile
{
    public InsuranceTypeMappingProfile()
    {
        CreateMap<InsuranceType, InsuranceSummaryDto>()
            .ForMember(dest => dest.InsuranceTypeName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ContractsCount, opt => opt.MapFrom(src => src.Contracts.Count))
            .ForMember(dest => dest.TotalInsuranceAmount, opt => opt.MapFrom(src => src.Contracts.Sum(c => c.InsuranceAmount)))
            .ForMember(dest => dest.TotalPremiumAmount, opt => opt.MapFrom(src => src.Contracts.Sum(c => c.PremiumAmount)))
            .ReverseMap();

    }
}