using StockTrackingCore.Entities.Abstract;

namespace StockTrackingCore.Entities.Concrete
{
    public class Barcode : BaseEntity, IEntity
    {
        public string BarcodeNumber { get; set; }

        public int ProductId { get; set; } //Fk
        public Product Product { get; set; }
    }
}
