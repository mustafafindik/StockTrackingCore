using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.DataAccess.Concrete.EntityFramework.Contexts;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework
{
    public class BarcodeRepository : BaseRepository<Barcode>, IBarcodeRepository
    {
        public BarcodeRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
