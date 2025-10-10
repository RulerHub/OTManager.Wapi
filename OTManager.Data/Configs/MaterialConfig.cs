using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OTManager.Core.Entities.OT;

namespace OTManager.Data.Configs;

/// <summary>
/// Configuración de la entidad Material para EF Core.
/// </summary>
public class MaterialConfig : IEntityTypeConfiguration<Material>
{
    /// <summary>
    /// Configura la entidad Material.
    /// </summary>
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.ToTable(nameof(Material));
        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.Code).IsUnique();
        builder.HasIndex(p => p.Name);
        builder.HasIndex(p => p.CreatedAt);

        builder.Property(p => p.Code).IsRequired().HasMaxLength(32);
        builder.Property(p => p.UnitCost).HasColumnType("decimal(18,2)").HasDefaultValue(0.00m);
        builder.Property(p => p.CreatedAt).IsRequired(false);
        builder.Property(p => p.CreatedBy).HasMaxLength(100);
        builder.Property(p => p.UpdatedAt).IsRequired(false);
        builder.Property(p => p.UpdatedBy).HasMaxLength(100);
        //builder.Property(f => f.Quantity).HasColumnType("decimal(18,6)").HasDefaultValue(0.00);
    }
}
