using FinBeat.Domain.Entities.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinBeat.Infrastructure.Persistence.Configurations.Logging
{
    public class RequestLogConfiguration : IEntityTypeConfiguration<RequestLog>
    {
        public void Configure(EntityTypeBuilder<RequestLog> builder)
        {
            builder.ToTable("RequestLogs");

            builder.HasKey(rl => rl.Id);

            builder.Property(rl => rl.Method)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(rl => rl.Url)
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(rl => rl.Headers)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(rl => rl.Body)
                .HasColumnType("text");

            builder.Property(rl => rl.Timestamp)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(rl => rl.CorrelationId)
                .IsRequired();
        }
    }
}
