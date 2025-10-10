using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OTManager.Core.Entities.OT;

namespace OTManager.Data.Configs;

public class WorkerCostConfig : IEntityTypeConfiguration<WorkerCost>
{
    public void Configure(EntityTypeBuilder<WorkerCost> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasIndex(s => s.Name);
        builder.HasIndex(s => s.CreatedAt);

        builder.Property(s => s.HourlyRate).HasColumnType("decimal(2,4)").HasDefaultValue(0.00);
        builder.Property(s => s.HoursWorked).HasColumnType("decimal(2,4)").HasDefaultValue(0.00);
        builder.Property(s => s.TotalCost).HasColumnType("decimal(2,4)").HasDefaultValue(0.00);
    }
}
