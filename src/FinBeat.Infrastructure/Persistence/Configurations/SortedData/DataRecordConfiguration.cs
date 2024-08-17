using FinBeat.Domain.Entities.SortedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinBeat.Infrastructure.Persistence.Configurations.SortedData;

public class DataRecordConfiguration : IEntityTypeConfiguration<DataRecord>
{
    public void Configure(EntityTypeBuilder<DataRecord> builder)
    {
        builder.ToTable("DataRecords");

        builder.HasKey(dr => dr.Id);

        builder.Property(dr => dr.OrderNumber)
            .IsRequired();

        builder.Property(dr => dr.Code)
            .IsRequired();

        builder.Property(dr => dr.Value)
            .IsRequired();
    }
}
