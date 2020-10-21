using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackingCore.Api.Dtos
{
    public class WarehouseDetailDto
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int CityId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
