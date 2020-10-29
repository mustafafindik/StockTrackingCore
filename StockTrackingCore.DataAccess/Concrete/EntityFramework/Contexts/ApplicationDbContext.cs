using Microsoft.EntityFrameworkCore;
using StockTrackingCore.DataAccess.Concrete.EntityFramework.Builders;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<VatRate> VatRates { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Barcode> Barcodes { get; set; }
        public DbSet<StockType> StockTypes { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BarcodeBuilder());
            modelBuilder.ApplyConfiguration(new CategoryBuilder());
            modelBuilder.ApplyConfiguration(new CityBuilder());
            modelBuilder.ApplyConfiguration(new CustomerBuilder());
            modelBuilder.ApplyConfiguration(new ProductBuilder());
            modelBuilder.ApplyConfiguration(new StockBuilder());
            modelBuilder.ApplyConfiguration(new StockTypeBuilder());
            modelBuilder.ApplyConfiguration(new SubCategoryBuilder());
            modelBuilder.ApplyConfiguration(new SupplierBuilder());
            modelBuilder.ApplyConfiguration(new UnitBuilder());
            modelBuilder.ApplyConfiguration(new UserBuilder());
            modelBuilder.ApplyConfiguration(new VatRateBuilder());
            modelBuilder.ApplyConfiguration(new WarehouseBuilder());

        }
    }
}
