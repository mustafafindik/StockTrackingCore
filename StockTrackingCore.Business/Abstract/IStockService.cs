using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;

namespace StockTrackingCore.Business.Abstract
{
    public interface IStockService
    {
        IList<Stock> GetAll();
        IList<Stock> GetAll(params string[] navigations);
        Stock Get(int id);
        Stock Get(int id, params string[] navigations);
        void Add(Stock stock);
        void Update(Stock stock);
        void Delete(int id);
    }
}
