﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SafeHaven.DAL;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(builder =>
    {
        builder.Sources.Clear();
        builder.AddJsonFile("appsettings.json", true, false);
        builder.AddJsonFile("appsettings.local.json", true, false);
        builder.AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) =>
    {
        var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<InsuranceDbContext>(options => { options.UseNpgsql(connectionString); });
    }).Build();

var logger = LoggerFactory.Create(builder => { builder.AddConsole(); }).CreateLogger<Program>();

using (var scope = host.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<InsuranceDbContext>();
    var pendingMigrations = dbContext.Database.GetPendingMigrations().ToList();
    if (pendingMigrations.Count != 0)
    {
        await dbContext.Database.MigrateAsync();
        foreach (var appliedMigration in pendingMigrations)
        {
            logger.LogInformation("Применена миграция {appliedMigration}", appliedMigration);
        }
    }
    else
    {
        logger.LogInformation("Миграций, ожидающих выполнения, нет");
    }
}