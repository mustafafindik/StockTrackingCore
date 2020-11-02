using System;

namespace StockTrackingCore.Api.Dtos
{
    public class VatRateDetailDto
    {
        public int Id { get; set; }
        public string VatRateName { get; set; }
        public decimal VatRateValue { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
