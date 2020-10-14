using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;

namespace StockTrackingCore.Business.Abstract
{
    public interface IProductService
    {
        IList<Product> GetAll();
        IList<Product> GetAll(params string[] navigations);
        Product Get(int id);
        Product Get(int id, params string[] navigations);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
