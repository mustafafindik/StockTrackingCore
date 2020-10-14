using System;
using System.ComponentModel.DataAnnotations;

namespace StockTrackingCore.Entities.Concrete
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", NullDisplayText = "Oluşturma Tarihi Girilmemiş")]
        public DateTime CreateDate { get; set; }

        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        public string CreatedBy { get; set; }

        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", NullDisplayText = "Güncelleme Tarihi Girilmemiş")]
        public DateTime ModifiedDate { get; set; }
    }
}
