using StockTrackingCore.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockTrackingCore.Entities.Concrete
{
    public class VatRate : BaseEntity, IEntity
    {
        public string VatRateName { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal VatRateValue { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
