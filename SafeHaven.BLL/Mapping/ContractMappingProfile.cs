using AutoMapper;
using SafeHaven.BLL.Dto;
using SafeHaven.DAL.Entities;

namespace SafeHaven.BLL.Mapping;

public class ContractMappingProfile : Profile
{
    public ContractMappingProfile()
    {
        CreateMap<Contract, ContractDto>()
            .ReverseMap();
    }
}