using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework.Builders
{
    public class BarcodeBuilder : IEntityTypeConfiguration<Barcode>
    {
        public void Configure(EntityTypeBuilder<Barcode> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.BarcodeNumber).IsRequired().HasMaxLength(20);
            builder.HasOne(p => p.Product).WithMany(c => c.Barcodes).HasForeignKey(p => p.ProductId);
        }
    }
}
