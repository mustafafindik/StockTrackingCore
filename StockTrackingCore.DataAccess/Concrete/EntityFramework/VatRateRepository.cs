using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.DataAccess.Concrete.EntityFramework.Contexts;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework
{
    public class VatRateRepository : BaseRepository<VatRate>, IVatRateRepository
    {
        public VatRateRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
