using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeHaven.DAL.Entities;

namespace SafeHaven.DAL.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.FullName).IsRequired().HasMaxLength(200);
        builder.Property(c => c.PassportNumber).HasMaxLength(20);
        builder.Property(c => c.Email).HasMaxLength(100);

        builder.HasMany(c => c.Contracts)
            .WithOne(c => c.Client)
            .OnDelete(DeleteBehavior.Cascade);
    }
}