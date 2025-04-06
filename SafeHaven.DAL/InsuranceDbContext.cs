using Microsoft.EntityFrameworkCore;
using SafeHaven.DAL.Configurations;
using SafeHaven.DAL.Entities;

namespace SafeHaven.DAL;

public class InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<InsuranceType> InsuranceTypes { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<InsuranceCase> InsuranceCases { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new InsuranceTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ContractConfiguration());
        modelBuilder.ApplyConfiguration(new InsuranceCaseConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}