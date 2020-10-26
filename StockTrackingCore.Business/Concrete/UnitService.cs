using StockTrackingCore.Business.Abstract;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace StockTrackingCore.Business.Concrete
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public IList<Unit> GetAll()
        {
            return _unitRepository.GetAll().ToList();
        }

        public IList<Unit> GetAll(params string[] navigations)
        {
            return _unitRepository.GetAll(navigations).ToList();
        }

        public Unit Get(int id)
        {
            return _unitRepository.Get(id);
        }

        public Unit Get(int id, params string[] navigations)
        {
            return _unitRepository.Get(id, navigations);
        }

        public void Add(Unit unit)
        {
            _unitRepository.Add(unit);
        }

        public void Update(Unit unit)
        {
            _unitRepository.Update(unit);
        }

        public void Delete(int id)
        {
            var entity = _unitRepository.Get(id);
            if (entity != null)
            {
                _unitRepository.Delete(entity);
            }
        }

        public void DeleteSelected(List<int> ids)
        {
            var entity = _unitRepository.GetAll().Where(x => ids.Contains(x.Id)).ToList();
            if (entity.Count > 0)
            {
                _unitRepository.DeleteSelected(entity);
            }
        }
    }
}
