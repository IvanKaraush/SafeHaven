using AutoMapper;
using SafeHaven.BLL.Dto;
using SafeHaven.DAL.Entities;

namespace SafeHaven.BLL.Mapping;

public class InsuranceCaseMappingProfile : Profile
{
    public InsuranceCaseMappingProfile()
    {
        CreateMap<InsuranceCase, InsuranceCaseDto>()
            .ForMember(dto => dto.ContractId, opt => opt.Ignore())
            .ReverseMap();
    }
}