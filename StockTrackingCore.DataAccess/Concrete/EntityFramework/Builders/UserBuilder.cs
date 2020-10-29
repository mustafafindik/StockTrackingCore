using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTrackingCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

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
