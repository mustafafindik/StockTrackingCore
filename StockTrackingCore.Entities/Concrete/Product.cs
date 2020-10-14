using StockTrackingCore.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockTrackingCore.Entities.Concrete
{
    public class Product : BaseEntity, IEntity
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Desc { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SalePrice { get; set; }

        public int UnitId { get; set; } //FK
        public Unit Unit { get; set; }

        public int VatRateId { get; set; } //Fk
        public VatRate VatRate { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sim { get; set; }

        public int WarehouseId { get; set; } //Fk
        public Warehouse Warehouse { get; set; }

        public int SubCategoryId { get; set; } //Fk
        public SubCategory SubCategory { get; set; }



        public virtual ICollection<Barcode> Barcodes { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
