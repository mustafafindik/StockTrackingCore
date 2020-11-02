using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework.Builders
{
    class SupplierBuilder : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.SupplierName).IsRequired().HasMaxLength(200);


        }
    }
}
