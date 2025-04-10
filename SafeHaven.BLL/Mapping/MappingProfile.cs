using AutoMapper;
using SafeHaven.BLL.Dto;
using SafeHaven.DAL.Entities;

namespace SafeHaven.BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientDto>().ReverseMap();
            
        CreateMap<Contract, ContractDto>()
            .ForMember(dto => dto.ClientId, opt => opt.MapFrom(entity => entity.Client.Id))
            .ForMember(dto => dto.InsuranceTypeId, opt => opt.MapFrom(entity => entity.InsuranceType.Id))
            .ReverseMap();
            
        CreateMap<InsuranceCase, InsuranceCaseDto>()
            .ForMember(dto => dto.ContractId, opt => opt.MapFrom(entity => entity.Contract.Id))
            .ReverseMap();

        CreateMap<InsuranceType, InsuranceTypeDto>().ReverseMap();

        CreateMap<Payment, PaymentDto>()
            .ForMember(dto => dto.ContractId, opt => opt.MapFrom(entity => entity.Contract.Id))
            .ReverseMap();
    }
}