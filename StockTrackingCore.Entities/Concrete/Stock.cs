using StockTrackingCore.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockTrackingCore.Entities.Concrete
{
    public class Stock : BaseEntity, IEntity
    {
        public int StockTypeId { get; set; }
        public StockType StockType { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public DateTime AddDate { get; set; }
    }
}
