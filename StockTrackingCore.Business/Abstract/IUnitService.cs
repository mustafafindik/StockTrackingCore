using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;

namespace StockTrackingCore.Business.Abstract
{
    public interface IUnitService
    {
        IList<Unit> GetAll();
        IList<Unit> GetAll(params string[] navigations);
        Unit Get(int id);
        Unit Get(int id, params string[] navigations);
        void Add(Unit unit);
        void Update(Unit unit);
        void Delete(int id);
        void DeleteSelected(List<int> ids);
    }
}
