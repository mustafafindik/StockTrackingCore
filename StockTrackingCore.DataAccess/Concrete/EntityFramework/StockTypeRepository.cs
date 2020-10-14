using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.DataAccess.Concrete.EntityFramework.Contexts;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework
{
    public class StockTypeRepository : BaseRepository<StockType>, IStockTypeRepository
    {
        public StockTypeRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
