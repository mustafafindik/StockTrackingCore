﻿using StockTrackingCore.Entities.Abstract;

namespace StockTrackingCore.Entities.Concrete
{
    public class Supplier : BaseEntity, IEntity
    {
        public string SupplierName { get; set; }
        public string TaxId { get; set; }
        public string TaxOffice { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
