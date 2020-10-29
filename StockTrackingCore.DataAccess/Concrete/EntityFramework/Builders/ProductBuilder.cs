using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework.Builders
{


    public class ProductBuilder : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(200);
            builder.Property(p => p.ProductCode).IsRequired().HasMaxLength(200);
            builder.HasOne(p => p.SubCategory).WithMany(c => c.Products).HasForeignKey(p => p.SubCategoryId);
            builder.HasOne(p => p.Unit).WithMany(c => c.Products).HasForeignKey(p => p.UnitId);
            builder.HasOne(p => p.SalesVatRate).WithMany().HasForeignKey(p => p.SalesVatRateId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Warehouse).WithMany(c => c.Products).HasForeignKey(p => p.WarehouseId);
            builder.HasOne(p => p.PurchaseVatRate).WithMany().HasForeignKey(p => p.PurchaseVatRateId).OnDelete(DeleteBehavior.Restrict);
        }
    }


}
