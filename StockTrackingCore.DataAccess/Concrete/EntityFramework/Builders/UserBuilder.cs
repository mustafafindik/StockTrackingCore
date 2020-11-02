using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework.Builders
{
    public class UserBuilder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

        }
    }


}
