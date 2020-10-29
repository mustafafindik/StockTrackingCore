using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTrackingCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework.Builders
{
    class CustomerBuilder : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CustomerName).IsRequired().HasMaxLength(200);

        }
    }
}