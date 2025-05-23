﻿using Microsoft.AspNetCore.Mvc;
using SafeHaven.BLL.Dto;
using SafeHaven.BLL.Interfaces;

namespace SafeHaven.API.Controllers;

/// <summary>
/// Контроллер для работы с договорами страхования.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ContractController : ControllerBase
{
    private readonly IContractService _contractService;

    /// <summary>
    /// Конструктор контроллера, внедрение зависимостей через DI.
    /// </summary>
    /// <param name="contractService">Сервис для работы с договорами.</param>
    public ContractController(IContractService contractService)
    {
        _contractService = contractService;
    }

    [HttpGet("{page:int}/{pageSize:int}")]
    public async Task<IActionResult> GetContractsWithPagination([FromRoute] int page, int pageSize)
    {
        var contracts = await _contractService.GetItemWithPaginationAsync(page, pageSize);
        return Ok(contracts);
    }

    /// <summary>
    /// Получение действующих договоров.
    /// Договор считается действующим, если его статус активен и текущая дата находится между StartDate и EndDate.
    /// </summary>
    /// <returns>Список активных договоров в формате ContractDto.</returns>
    [HttpGet("active")]
    public async Task<IActionResult> GetActiveContracts()
    {
        var activeContracts = await _contractService.GetActiveContractsAsync();
        return Ok(activeContracts);
    }

    /// <summary>
    /// Получение договоров с премией меньше указанного значения.
    /// </summary>
    /// <param name="value">Пороговое значение премии.</param>
    /// <returns>Список договоров в формате ContractDto.</returns>
    [HttpGet("premium/less-than/{value:decimal}")]
    public async Task<IActionResult> GetContractsWithPremiumLessThan(decimal value)
    {
        var contracts = await _contractService.GetContractsWithPremiumLessThanAsync(value);
        return Ok(contracts);
    }

    /// <summary>
    /// Получение договоров с премией больше указанного значения.
    /// </summary>
    /// <param name="value">Пороговое значение премии.</param>
    /// <returns>Список договоров в формате ContractDto.</returns>
    [HttpGet("premium/greater-than/{value:decimal}")]
    public async Task<IActionResult> GetContractsWithPremiumGreaterThan(decimal value)
    {
        var contracts = await _contractService.GetContractsWithPremiumGreaterThanAsync(value);
        return Ok(contracts);
    }

    /// <summary>
    /// Получение сводной информации по договорам для конкретного типа страхования.
    /// </summary>
    /// <param name="insuranceTypeName">Название типа страхования.</param>
    /// <returns>Объект InsuranceSummaryDto с агрегированными данными.</returns>
    [HttpGet("summary/{insuranceTypeName}")]
    public async Task<IActionResult> GetSummaryByInsuranceType(string insuranceTypeName)
    {
        var summary = await _contractService.GetSummaryByInsuranceTypeAsync(insuranceTypeName);
        return Ok(summary);
    }

    /// <summary>
    /// Получение договора по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор договора.</param>
    /// <returns>Договор в формате ContractDto.</returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var contract = await _contractService.GetByIdAsync(id);
        return Ok(contract);
    }

    /// <summary>
    /// Создание нового договора.
    /// Принимает объект ContractDto, маппит его в доменную сущность и добавляет в базу.
    /// </summary>
    /// <param name="contractDto">DTO нового договора.</param>
    /// <returns>Созданный договор в формате ContractDto.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ContractDto contractDto)
    {
        var contractId = await _contractService.CreateAsync(contractDto);
        return CreatedAtAction(nameof(GetById), new { id = contractId }, contractId);
    }

    /// <summary>
    /// Обновление существующего договора.
    /// </summary>
    /// <param name="contractDto">Обновленные данные договора.</param>
    /// <returns>Результат операции.</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ContractDto contractDto)
    {
        await _contractService.UpdateAsync(contractDto);
        return NoContent();
    }

    /// <summary>
    /// Удаление существующего договора.
    /// </summary>
    /// <param name="id">Идентификатор договора.</param>
    /// <returns>Результат операции.</returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _contractService.DeleteAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Получение типа страхования по идентификатору договора.
    /// </summary>
    /// <param name="id">Идентификатор договора.</param>
    /// <returns>Объект InsuranceTypeDto.</returns>
    [HttpGet("insurance-type/{id:guid}")]
    public async Task<IActionResult> GetInsuranceTypeById(Guid id)
    {
        var insuranceType = await _contractService.GetInsuranceTypeByIdAsync(id);
        return Ok(insuranceType);
    }

    /// <summary>
    /// Получение типов страхования с пагинацией.
    /// Извлекается тип страхования из каждого договора.
    /// </summary>
    /// <param name="page">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Коллекция объектов InsuranceTypeDto.</returns>
    [HttpGet("insurance-type/pagination/{page:int}/{pageSize:int}")]
    public async Task<IActionResult> GetInsuranceTypesWithPagination(int page, int pageSize)
    {
        var insuranceTypes = await _contractService.GetInsuranceTypeWithPaginationAsync(page, pageSize);
        return Ok(insuranceTypes);
    }

    /// <summary>
    /// Получение платежей по идентификатору договора.
    /// </summary>
    /// <param name="id">Идентификатор договора.</param>
    /// <returns>Объект PaymentDto.</returns>
    [HttpGet("payment/{id:guid}")]
    public async Task<IActionResult> GetPaymentByContractId(Guid id)
    {
        var payments = await _contractService.GetPaymentByContractIdAsync(id);
        return Ok(payments);
    }

    /// <summary>
    /// Получение страхового случая по идентификатору договора.
    /// </summary>
    /// <param name="id">Идентификатор договора.</param>
    /// <returns>Объект InsuranceCaseDto.</returns>
    [HttpGet("insurance-case/{id:guid}")]
    public async Task<IActionResult> GetInsuranceCaseByContractId(Guid id)
    {
        var insuranceCase = await _contractService.GetInsuranceCaseByContractIdAsync(id);
        return Ok(insuranceCase);
    }
}
