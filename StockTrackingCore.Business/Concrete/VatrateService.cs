using StockTrackingCore.Business.Abstract;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace StockTrackingCore.Business.Concrete
{
    public class VatRateService : IVatRateService
    {
        private readonly IVatRateRepository _vatRateRepository;

        public VatRateService(IVatRateRepository vatRateRepository)
        {
            _vatRateRepository = vatRateRepository;
        }

        public IList<VatRate> GetAll()
        {
            return _vatRateRepository.GetAll().ToList();
        }

        public IList<VatRate> GetAll(params string[] navigations)
        {
            return _vatRateRepository.GetAll(navigations).ToList();
        }

        public VatRate Get(int id)
        {
            return _vatRateRepository.Get(id);
        }

        public VatRate Get(int id, params string[] navigations)
        {
            return _vatRateRepository.Get(id, navigations);
        }

        public void Add(VatRate vatRate)
        {
            _vatRateRepository.Add(vatRate);
        }

        public void Update(VatRate vatRate)
        {
            _vatRateRepository.Update(vatRate);
        }

        public void Delete(int id)
        {
            var entity = _vatRateRepository.Get(id);
            if (entity != null)
            {
                _vatRateRepository.Delete(entity);
            }
        }
    }
}
