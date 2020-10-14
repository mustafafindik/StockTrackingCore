using StockTrackingCore.Business.Abstract;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace StockTrackingCore.Business.Concrete
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public IList<Stock> GetAll()
        {
            return _stockRepository.GetAll().ToList();
        }

        public IList<Stock> GetAll(params string[] navigations)
        {
            return _stockRepository.GetAll(navigations).ToList();
        }

        public Stock Get(int id)
        {
            return _stockRepository.Get(id);
        }

        public Stock Get(int id, params string[] navigations)
        {
            return _stockRepository.Get(id, navigations);
        }

        public void Add(Stock stock)
        {
            _stockRepository.Add(stock);
        }

        public void Update(Stock stock)
        {
            _stockRepository.Update(stock);
        }

        public void Delete(int id)
        {
            var entity = _stockRepository.Get(id);
            if (entity != null)
            {
                _stockRepository.Delete(entity);
            }
        }
    }
}
