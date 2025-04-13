using AutoMapper;
using SafeHaven.BLL.Dto;
using SafeHaven.BLL.Exceptions;
using SafeHaven.BLL.Interfaces;
using SafeHaven.DAL.Entities;
using SafeHaven.DAL.Interfaces;

namespace SafeHaven.BLL.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public ClientService(IClientRepository clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<ClientDto> GetByIdAsync(Guid id)
    {
        var client = await _clientRepository.GetByFilterAsync(c => c.Id == id) ??
            throw new NotFoundException($"Не найден клиент {id}");
        return _mapper.Map<ClientDto>(client);
    }

    public async Task<ClientDto[]> GetItemWithPaginationAsync(int page, int pageSize)
    {
        var allClients = await _clientRepository.GetPaginatedAsync(page, pageSize);
        return _mapper.Map<ClientDto[]>(allClients);
    }

    public async Task<Guid> CreateAsync(ClientDto clientDto)
    {
        var client = await _clientRepository.GetByFilterAsync(c => c.Id == clientDto.Id);
        if (client != null)
        {
            throw new NotFoundException($"Такой клиент уже существует {clientDto.Id}");
        }

        var newClient = new Client(clientDto.FullName, clientDto.DateOfBirth, clientDto.PassportNumber,
            clientDto.Address, clientDto.Phone, clientDto.Email);
        await _clientRepository.AddAsync(newClient);
        await _clientRepository.SaveChangesAsync();
        return newClient.Id;
    }

    public async Task UpdateAsync(ClientDto clientDto)
    {
        var client = await _clientRepository.GetByFilterAsync(c => c.Id == clientDto.Id) ??
                     throw new NotFoundException($"Не найден клиент {clientDto.Id}");

        client.Update(clientDto.FullName, clientDto.DateOfBirth, clientDto.PassportNumber, clientDto.Address,
            clientDto.Phone, clientDto.Email);
        await _clientRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var client = await _clientRepository.GetByFilterAsync(c => c.Id == id) ??
                     throw new NotFoundException($"Не найден клиент {id}");
        _clientRepository.Remove(client);
        await _clientRepository.SaveChangesAsync();
    }
}