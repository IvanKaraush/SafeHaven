using AutoMapper;
using SafeHaven.BLL.Dto;
using SafeHaven.DAL.Entities;

namespace SafeHaven.BLL.Mapping;

public class InsuranceTypeMappingProfile : Profile
{
    public InsuranceTypeMappingProfile()
    {
        CreateMap<InsuranceType, InsuranceTypeDto>().ReverseMap();
    }
}