using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;

namespace StockTrackingCore.Business.Abstract
{
    public interface ISubCategoryService
    {
        IList<SubCategory> GetAll();
        IList<SubCategory> GetAll(params string[] navigations);
        SubCategory Get(int id);
        SubCategory Get(int id, params string[] navigations);
        void Add(SubCategory subCategory);
        void Update(SubCategory subCategory);
        void Delete(int id);
    }
}
