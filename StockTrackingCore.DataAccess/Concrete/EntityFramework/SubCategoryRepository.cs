using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.DataAccess.Concrete.EntityFramework.Contexts;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework
{
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
