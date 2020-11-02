using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;

namespace StockTrackingCore.Business.Abstract
{
    public interface ISupplierService
    {
        IList<Supplier> GetAll();
        IList<Supplier> GetAll(params string[] navigations);
        Supplier Get(int id);
        Supplier Get(int id, params string[] navigations);
        void Add(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(int id);
        void DeleteSelected(List<int> ids);
    }
}
