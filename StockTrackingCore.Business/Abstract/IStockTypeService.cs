using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;

namespace StockTrackingCore.Business.Abstract
{
    public interface IStockTypeService
    {
        IList<StockType> GetAll();
        IList<StockType> GetAll(params string[] navigations);
        StockType Get(int id);
        StockType Get(int id, params string[] navigations);
        void Add(StockType stockType);
        void Update(StockType stockType);
        void Delete(int id);
    }
}
