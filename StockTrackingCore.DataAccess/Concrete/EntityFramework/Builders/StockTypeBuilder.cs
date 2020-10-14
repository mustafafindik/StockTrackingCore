using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework.Builders
{
    public class StockTypeBuilder : IEntityTypeConfiguration<StockType>
    {
        public void Configure(EntityTypeBuilder<StockType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.StockTypeName).IsRequired().HasMaxLength(200);

        }
    }
}
