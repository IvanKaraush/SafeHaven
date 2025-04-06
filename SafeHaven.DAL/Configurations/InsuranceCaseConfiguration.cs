using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeHaven.DAL.Entities;

namespace SafeHaven.DAL.Configurations;

public class InsuranceCaseConfiguration : IEntityTypeConfiguration<InsuranceCase>
{
    public void Configure(EntityTypeBuilder<InsuranceCase> builder)
    {
        builder.HasKey(ic => ic.Id);
        builder.Property(ic => ic.Description).HasMaxLength(500);
        builder.Property(ic => ic.PayoutAmount).HasColumnType("decimal(18,2)");
    }
}