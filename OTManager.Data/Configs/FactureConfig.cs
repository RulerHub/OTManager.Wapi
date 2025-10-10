using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OTManager.Core.Entities.OT;

namespace OTManager.Data.Configs;

/// <summary>
/// Configuración de la entidad Facture para EF Core.
/// </summary>
public class FactureConfig : IEntityTypeConfiguration<Facture>
{
    /// <summary>
    /// Configura la entidad Facture.
    /// </summary>
    public void Configure(EntityTypeBuilder<Facture> builder)
    {
        builder.ToTable(nameof(Facture));
        builder.HasKey(f => f.Id);

        builder.HasIndex(f => f.Code).IsUnique();
        builder.HasIndex(f => f.CreatedAt);

        builder.Property(f => f.Code).IsRequired().HasMaxLength(10);
        builder.Property(f => f.TotalPrice).HasColumnType("decimal(18,2)").HasDefaultValue(0.00m);
        builder.Property(f => f.CreatedAt).IsRequired(false);
        builder.Property(f => f.CreatedBy).HasMaxLength(100);
        builder.Property(f => f.UpdatedAt).IsRequired(false);
        builder.Property(f => f.UpdatedBy).HasMaxLength(100);
    }
}
