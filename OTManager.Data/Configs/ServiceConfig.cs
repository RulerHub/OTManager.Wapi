using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OTManager.Core.Entities.OT;

namespace OTManager.Data.Configs;

public class ServiceConfig : IEntityTypeConfiguration<ServiceOrder>
{
    public void Configure(EntityTypeBuilder<ServiceOrder> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasIndex(s => s.Name);
        builder.HasIndex(s => s.CreatedAt);

        builder.Property(s => s.Price).HasColumnType("decimal(18,2)").HasDefaultValue(0.00);
    }
}
