using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;

namespace StockTrackingCore.Business.Abstract
{
    public interface IVatRateService
    {
        IList<VatRate> GetAll();
        IList<VatRate> GetAll(params string[] navigations);
        VatRate Get(int id);
        VatRate Get(int id, params string[] navigations);
        void Add(VatRate vatRate);
        void Update(VatRate vatRate);
        void Delete(int id);
    }
}
