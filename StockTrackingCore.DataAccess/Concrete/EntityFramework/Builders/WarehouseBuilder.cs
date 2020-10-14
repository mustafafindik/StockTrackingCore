using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework.Builders
{
    public class WarehouseBuilder : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.WarehouseName).IsRequired().HasMaxLength(200);
            builder.HasOne(p => p.City).WithMany(c => c.Warehouses).HasForeignKey(p => p.CityId);
        }
    }
}
