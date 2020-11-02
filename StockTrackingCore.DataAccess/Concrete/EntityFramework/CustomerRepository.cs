using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.DataAccess.Concrete.EntityFramework.Contexts;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
