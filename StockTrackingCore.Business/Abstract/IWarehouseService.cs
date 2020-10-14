using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;

namespace StockTrackingCore.Business.Abstract
{
    public interface IWarehouseService
    {
        IList<Warehouse> GetAll();
        IList<Warehouse> GetAll(params string[] navigations);
        Warehouse Get(int id);
        Warehouse Get(int id, params string[] navigations);
        void Add(Warehouse warehouse);
        void Update(Warehouse warehouse);
        void Delete(int id);
    }
}
