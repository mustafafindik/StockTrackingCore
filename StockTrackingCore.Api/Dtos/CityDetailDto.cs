﻿using System;

namespace StockTrackingCore.Api.Dtos
{
    public class CityDetailDto
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
