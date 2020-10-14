using StockTrackingCore.Business.Abstract;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace StockTrackingCore.Business.Concrete
{
    public class StockTypeService : IStockTypeService
    {
        private readonly IStockTypeRepository _stockTypeRepository;

        public StockTypeService(IStockTypeRepository stockTypeRepository)
        {
            _stockTypeRepository = stockTypeRepository;
        }

        public IList<StockType> GetAll()
        {
            return _stockTypeRepository.GetAll().ToList();
        }

        public IList<StockType> GetAll(params string[] navigations)
        {
            return _stockTypeRepository.GetAll(navigations).ToList();
        }

        public StockType Get(int id)
        {
            return _stockTypeRepository.Get(id);
        }

        public StockType Get(int id, params string[] navigations)
        {
            return _stockTypeRepository.Get(id, navigations);
        }

        public void Add(StockType stockType)
        {
            _stockTypeRepository.Add(stockType);
        }

        public void Update(StockType stockType)
        {
            _stockTypeRepository.Update(stockType);
        }

        public void Delete(int id)
        {
            var entity = _stockTypeRepository.Get(id);
            if (entity != null)
            {
                _stockTypeRepository.Delete(entity);
            }
        }
    }
}
