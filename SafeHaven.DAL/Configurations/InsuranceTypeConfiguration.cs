using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeHaven.DAL.Entities;
namespace SafeHaven.DAL.Configurations;

public class InsuranceTypeConfiguration : IEntityTypeConfiguration<InsuranceType>
{
    public void Configure(EntityTypeBuilder<InsuranceType> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Name).IsRequired().HasMaxLength(100);

        builder.HasMany(i => i.Contracts)
            .WithOne(c => c.InsuranceType)
            .HasForeignKey(c => c.Id);
    }
}