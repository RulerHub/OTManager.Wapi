using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OTManager.Core.Entities.OT;

namespace OTManager.Data.Configs;

/// <summary>
/// Configuración de la entidad Order para EF Core.
/// </summary>
public class OrderConfig : IEntityTypeConfiguration<Order>
{
    /// <summary>
    /// Configura la entidad Order.
    /// </summary>
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(nameof(Order));
        builder.HasKey(o => o.Id);

        builder.HasIndex(o => o.OrderNumber).IsUnique();
        builder.HasIndex(o => o.CreatedAt);

        builder.Property(o => o.OrderNumber).IsRequired().HasMaxLength(10);
        builder.Property(o => o.TotalCost).HasColumnType("decimal(18,2)").HasDefaultValue(0.00m);
        builder.Property(o => o.CreatedAt).IsRequired(false);
        builder.Property(o => o.CreatedBy).HasMaxLength(100);
        builder.Property(o => o.UpdatedAt).IsRequired(false);
        builder.Property(o => o.UpdatedBy).HasMaxLength(100);

        builder.HasMany(o => o.Services)
            .WithOne(s => s.Order)
            .HasForeignKey(s => s.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(o => o.Materials)
            .WithOne(m => m.Order)
            .HasForeignKey(m => m.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(o => o.Workers)
            .WithOne(w => w.Order)
            .HasForeignKey(w => w.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
