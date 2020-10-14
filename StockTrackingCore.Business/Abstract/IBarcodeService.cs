using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;

namespace StockTrackingCore.Business.Abstract
{
    public interface IBarcodeService
    {
        IList<Barcode> GetAll();
        IList<Barcode> GetAll(params string[] navigations);
        Barcode Get(int id);
        Barcode Get(int id, params string[] navigations);
        void Add(Barcode barcode);
        void Update(Barcode barcode);
        void Delete(int id);
    }
}
