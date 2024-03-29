﻿using StockTrackingCore.Entities.Abstract;
using System.Collections.Generic;

namespace StockTrackingCore.Entities.Concrete
{
    public class City : BaseEntity, IEntity
    {
        public string CityName { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
