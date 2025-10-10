using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OTManager.Core.Entities.OT;

namespace OTManager.Data.Configs;

/// <summary>
/// Configuración de la entidad Cliente para EF Core.
/// </summary>
public class ClientConfig : IEntityTypeConfiguration<Client>
{
    /// <summary>
    /// Configura la entidad Cliente.
    /// </summary>
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable(nameof(Client));
        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.Code).IsUnique();
        builder.HasIndex(p => p.Name);
        builder.HasIndex(p => p.CreatedAt);

        builder.Property(p => p.Code).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.CreatedAt).IsRequired(false);
        builder.Property(p => p.CreatedBy).HasMaxLength(100);
        builder.Property(p => p.UpdatedAt).IsRequired(false);
        builder.Property(p => p.UpdatedBy).HasMaxLength(100);

        builder.HasMany(p => p.Orders)
            .WithOne(c => c.Client)
            .HasForeignKey(c => c.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Factures)
            .WithOne(f => f.Client)
            .HasForeignKey(f => f.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
