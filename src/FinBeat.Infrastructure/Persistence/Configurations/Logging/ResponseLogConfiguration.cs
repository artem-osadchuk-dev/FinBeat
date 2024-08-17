using FinBeat.Domain.Entities.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinBeat.Infrastructure.Persistence.Configurations.Logging
{
    public class ResponseLogConfiguration : IEntityTypeConfiguration<ResponseLog>
    {
        public void Configure(EntityTypeBuilder<ResponseLog> builder)
        {
            builder.ToTable("ResponseLogs");

            builder.HasKey(rl => rl.Id);

            builder.Property(rl => rl.Id)
                   .IsRequired();

            builder.Property(rl => rl.CorrelationId)
                   .IsRequired();

            builder.Property(rl => rl.StatusCode)
                   .IsRequired();

            builder.Property(rl => rl.Headers)
                   .IsRequired()
                   .HasColumnType("text");

            builder.Property(rl => rl.Body)
                   .HasColumnType("text");

            builder.Property(rl => rl.Timestamp)
                   .IsRequired()
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
