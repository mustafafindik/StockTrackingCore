using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework.Builders
{
    public class SubCategoryBuilder : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.SubCategoryName).IsRequired().HasMaxLength(200);
            builder.HasOne(p => p.Category).WithMany(c => c.SubCategories).HasForeignKey(p => p.CategoryId);

        }
    }
}
