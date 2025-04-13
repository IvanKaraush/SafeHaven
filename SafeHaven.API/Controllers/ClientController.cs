using Microsoft.AspNetCore.Mvc;
using SafeHaven.BLL.Dto;
using SafeHaven.BLL.Interfaces;

namespace SafeHaven.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("{page:int}/{pageSize:int}")]
    public async Task<IActionResult> GetClients([FromRoute] int page, int pageSize)
    {
        var clients = await _clientService.GetItemWithPaginationAsync(page, pageSize);
        return Ok(clients);
    }

    [HttpGet("{clientId:guid}")]
    public async Task<IActionResult> GetClientById([FromRoute] Guid clientId)
    {
        var clients = await _clientService.GetByIdAsync(clientId);
        return Ok(clients);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] ClientDto clientDto)
    {
        var clientId = await _clientService.CreateAsync(clientDto);
        return Ok(clientId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateClient([FromBody] ClientDto clientDto)
    {
        await _clientService.UpdateAsync(clientDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteClient([FromRoute] Guid id)
    {
        await _clientService.DeleteAsync(id);
        return NoContent();
    }
}