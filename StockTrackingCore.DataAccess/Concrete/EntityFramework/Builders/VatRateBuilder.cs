using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework.Builders
{
    public class VatRateBuilder : IEntityTypeConfiguration<VatRate>
    {
        public void Configure(EntityTypeBuilder<VatRate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.VatRateName).IsRequired().HasMaxLength(200);
        }
    }
}
