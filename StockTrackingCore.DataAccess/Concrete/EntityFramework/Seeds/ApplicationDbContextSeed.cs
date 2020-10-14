using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockTrackingCore.DataAccess.Concrete.EntityFramework.Contexts;
using StockTrackingCore.Entities.Concrete;
using System;
using System.Linq;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework.Seeds
{
    public static class ApplicationDbContextSeed
    {
        public static void Seed(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Units.Any())
            {
                var units = new[] {
                    new Unit() {  UnitName = "Kg" , CreateDate = DateTime.Now , CreatedBy ="Seed" , ModifiedBy = "Seed" , ModifiedDate = DateTime.Now },
                    new Unit() {  UnitName = "Adet" , CreateDate = DateTime.Now , CreatedBy ="Seed" , ModifiedBy = "Seed" , ModifiedDate = DateTime.Now }
                };
                context.Units.AddRange(units);
                context.SaveChanges();
            }

            if (!context.VatRates.Any())
            {
                var vatrates = new[] {
                    new VatRate() {  VatRateName = "KVD'siz", VatRateValue=0  , CreateDate = DateTime.Now , CreatedBy ="Seed" , ModifiedBy = "Seed" , ModifiedDate = DateTime.Now },
                    new VatRate() {  VatRateName = "%1", VatRateValue= (decimal)0.01  , CreateDate = DateTime.Now , CreatedBy ="Seed" , ModifiedBy = "Seed" , ModifiedDate = DateTime.Now },
                    new VatRate() {  VatRateName = "%8", VatRateValue= (decimal)0.08  , CreateDate = DateTime.Now , CreatedBy ="Seed" , ModifiedBy = "Seed" , ModifiedDate = DateTime.Now },
                    new VatRate() {  VatRateName = "%18", VatRateValue= (decimal)0.18  , CreateDate = DateTime.Now , CreatedBy ="Seed" , ModifiedBy = "Seed" , ModifiedDate = DateTime.Now },
                    new VatRate() {  VatRateName = "%25", VatRateValue= (decimal)0.25  , CreateDate = DateTime.Now , CreatedBy ="Seed" , ModifiedBy = "Seed" , ModifiedDate = DateTime.Now },

                };
                context.VatRates.AddRange(vatrates);
                context.SaveChanges();
            }

            if (!context.Cities.Any())
            {
                var cities = new[] {
                    new City() {  CityName = "İstanbul" , CreateDate = DateTime.Now , CreatedBy ="Seed" , ModifiedBy = "Seed" , ModifiedDate = DateTime.Now },
                    new City() {  CityName = "Ankara" , CreateDate = DateTime.Now , CreatedBy ="Seed" , ModifiedBy = "Seed" , ModifiedDate = DateTime.Now },
                    new City() {  CityName = "İzmir" , CreateDate = DateTime.Now , CreatedBy ="Seed" , ModifiedBy = "Seed" , ModifiedDate = DateTime.Now }
                };
                context.Cities.AddRange(cities);
                context.SaveChanges();
            }

            if (!context.Warehouses.Any())
            {
                var warehouses = new[] {
                    new Warehouse() {  WarehouseName = "Depo Test" , CityId =1,  Address="Küçükyalı" , CreateDate = DateTime.Now , CreatedBy ="Seed" , ModifiedBy = "Seed" , ModifiedDate = DateTime.Now }

                };
                context.Warehouses.AddRange(warehouses);
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                var categories = new[] {
                    new Category() {  CategoryName="Ana Kategori" , CreateDate = DateTime.Now , CreatedBy ="Seed" , ModifiedBy = "Seed" , ModifiedDate = DateTime.Now }

                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            if (!context.SubCategories.Any())
            {
                var subCategories = new[] {
                    new SubCategory() {  SubCategoryName="Ana Alt Kategori", CategoryId=1 , CreateDate = DateTime.Now , CreatedBy ="Seed" , ModifiedBy = "Seed" , ModifiedDate = DateTime.Now }

                };
                context.SubCategories.AddRange(subCategories);
                context.SaveChanges();
            }

        }
    }
}
