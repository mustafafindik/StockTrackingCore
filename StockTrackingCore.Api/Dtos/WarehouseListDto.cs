using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackingCore.Api.Dtos
{
    public class WarehouseListDto
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
