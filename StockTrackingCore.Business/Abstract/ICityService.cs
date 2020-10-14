using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;

namespace StockTrackingCore.Business.Abstract
{
    public interface ICityService
    {
        IList<City> GetAll();
        IList<City> GetAll(params string[] navigations);
        City Get(int id);
        City Get(int id, params string[] navigations);
        void Add(City city);
        void Update(City city);
        void Delete(int id);
    }
}
