using StockTrackingCore.Business.Abstract;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace StockTrackingCore.Business.Concrete
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public void Add(City city)
        {
            _cityRepository.Add(city);
        }

        public void Delete(int id)
        {
            var entity = _cityRepository.Get(id);
            if (entity != null)
            {
                _cityRepository.Delete(entity);
            }
        }

        public void DeleteSelected(List<int> ids)
        {
            var entity = _cityRepository.GetAll().Where(x => ids.Contains(x.Id)).ToList();
            if (entity.Count>0)
            {
                _cityRepository.DeleteSelected(entity);
            }
        }

        public City Get(int id)
        {
            return _cityRepository.Get(id);
        }

        public City Get(int id, params string[] navigations)
        {
            return _cityRepository.Get(id, navigations);
        }

        public IList<City> GetAll()
        {
            return _cityRepository.GetAll().ToList();
        }

        public IList<City> GetAll(params string[] navigations)
        {
            return _cityRepository.GetAll(navigations).ToList();
        }

        public void Update(City city)
        {
            _cityRepository.Update(city);
        }
    }
}
