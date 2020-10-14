using StockTrackingCore.Entities.Abstract;
using System.Collections.Generic;

namespace StockTrackingCore.Entities.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        public string CategoryName { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
