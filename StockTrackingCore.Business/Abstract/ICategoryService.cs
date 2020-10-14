using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;

namespace StockTrackingCore.Business.Abstract
{
    public interface ICategoryService
    {
        IList<Category> GetAll();
        IList<Category> GetAll(params string[] navigations);
        Category Get(int id);
        Category Get(int id, params string[] navigations);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
