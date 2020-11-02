using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.DataAccess.Concrete.EntityFramework.Contexts;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
