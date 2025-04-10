﻿namespace SafeHaven.DAL.Entities;

/// <summary>
/// Представляет клиента страховой компании.
/// Содержит персональные данные и коллекцию договоров, заключенных данным клиентом.
/// </summary>
public class Client : BaseEntity
{
    /// <summary>
    /// Полное имя клиента.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Дата рождения клиента.
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Номер паспорта клиента.
    /// </summary>
    public string PassportNumber { get; set; }

    /// <summary>
    /// Адрес проживания клиента.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Контактный телефон клиента.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Электронная почта клиента.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Коллекция договоров страхования, заключенных с данным клиентом.
    /// Доступна только для чтения.
    /// </summary>
    public List<Contract> Contracts { get; set; } = [];

    /// <summary>
    /// Создает новый экземпляр клиента.
    /// </summary>
    /// <param name="fullName">Полное имя клиента.</param>
    /// <param name="dateOfBirth">Дата рождения клиента.</param>
    /// <param name="passportNumber">Номер паспорта клиента.</param>
    /// <param name="address">Адрес клиента.</param>
    /// <param name="phone">Телефон клиента.</param>
    /// <param name="email">Электронная почта клиента.</param>
    public Client(string fullName, DateTime dateOfBirth, string passportNumber, string address, string phone,
        string email)
    {
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        PassportNumber = passportNumber;
        Address = address;
        Phone = phone;
        Email = email;
    }
}