using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using StockTrackingCore.Business.Abstract;
using StockTrackingCore.Business.Concrete;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.DataAccess.Concrete.EntityFramework;
using StockTrackingCore.DataAccess.Concrete.EntityFramework.Contexts;
using StockTrackingCore.DataAccess.Concrete.EntityFramework.Seeds;
using System.Text;

namespace StockTrackingCore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            string Origins = Configuration["Appsettings:Origins"];
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(Origins).AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyHeader());
            });
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Appsettings:Token").Value);
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddTransient<ICityService, CityService>();

            services.AddScoped<IBarcodeRepository, BarcodeRepository>();
            services.AddTransient<IBarcodeService, BarcodeService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();

            services.AddScoped<IStockRepository, StockRepository>();
            services.AddTransient<IStockService, StockService>();

            services.AddScoped<IStockTypeRepository, StockTypeRepository>();
            services.AddTransient<IStockTypeService, StockTypeService>();

            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddTransient<ISubCategoryService, SubCategoryService>();

            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddTransient<IUnitService, UnitService>();

            services.AddScoped<IVatRateRepository, VatRateRepository>();
            services.AddTransient<IVatRateService, VatRateService>();

            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddTransient<IWarehouseService, WarehouseService>();

            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddTransient<ISupplierService, SupplierService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddTransient<ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("StockTrackingCore.Api")));



            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseAuthentication();



            ApplicationDbContextSeed.Seed(app); //Test Data.
        }
    }
}
