using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OTManager.Core.Entities.OT;

namespace OTManager.Data.Configs;

public class WorkerConfig : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasIndex(s => s.Name);
        builder.HasIndex(s => s.CreatedAt);

        builder.Property(s => s.HourlyRate).HasColumnType("decimal(2,4)").HasDefaultValue(0.00);
    }
}
