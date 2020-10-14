using StockTrackingCore.Entities.Abstract;
using System.Collections.Generic;

namespace StockTrackingCore.Entities.Concrete
{
    public class Unit : BaseEntity, IEntity
    {
        public string UnitName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
