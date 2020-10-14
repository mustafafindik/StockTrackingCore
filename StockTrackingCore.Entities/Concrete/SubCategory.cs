using StockTrackingCore.Entities.Abstract;
using System.Collections.Generic;

namespace StockTrackingCore.Entities.Concrete
{
    public class SubCategory : BaseEntity, IEntity
    {
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; } //Fk
        public Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
