﻿using System;

namespace StockTrackingCore.Api.Dtos
{
    public class UnitDetailDto
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
