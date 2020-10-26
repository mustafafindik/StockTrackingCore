using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackingCore.Api.Dtos
{
    public class VatRateListDto
    {
        public int Id { get; set; }
        public string VatRateName { get; set; }
        public decimal VatRateValue { get; set; }
    }
}
