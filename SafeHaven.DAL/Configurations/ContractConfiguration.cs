using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeHaven.DAL.Entities;

namespace SafeHaven.DAL.Configurations;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.ContractStatus).HasMaxLength(50);
        builder.Property(c => c.InsuranceAmount).HasColumnType("decimal(18,2)");
        builder.Property(c => c.PremiumAmount).HasColumnType("decimal(18,2)");

        builder.HasMany(c => c.InsuranceCases)
            .WithOne(ic => ic.Contract)
            .HasForeignKey(ic => ic.Id);

        builder.HasMany(c => c.Payments)
            .WithOne(p => p.Contract)
            .HasForeignKey(p => p.Id);
    }
}