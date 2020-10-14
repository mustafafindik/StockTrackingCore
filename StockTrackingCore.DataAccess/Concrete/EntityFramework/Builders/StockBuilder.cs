using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework.Builders
{
    public class StockBuilder : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.StockType).WithMany(c => c.Stocks).HasForeignKey(p => p.StockTypeId);
            builder.HasOne(p => p.Product).WithMany(c => c.Stocks).HasForeignKey(p => p.ProductId);

        }
    }
}
