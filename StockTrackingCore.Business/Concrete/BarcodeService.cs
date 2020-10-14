using StockTrackingCore.Business.Abstract;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace StockTrackingCore.Business.Concrete
{
    public class BarcodeService : IBarcodeService
    {
        private readonly IBarcodeRepository _barcodeRepository;

        public BarcodeService(IBarcodeRepository barcodeRepository)
        {
            _barcodeRepository = barcodeRepository;
        }

        public IList<Barcode> GetAll()
        {
            return _barcodeRepository.GetAll().ToList();
        }

        public IList<Barcode> GetAll(params string[] navigations)
        {
            return _barcodeRepository.GetAll(navigations).ToList();
        }

        public Barcode Get(int id)
        {
            return _barcodeRepository.Get(id);
        }

        public Barcode Get(int id, params string[] navigations)
        {
            return _barcodeRepository.Get(id, navigations);
        }

        public void Add(Barcode barcode)
        {
            _barcodeRepository.Add(barcode);
        }

        public void Update(Barcode barcode)
        {
            _barcodeRepository.Update(barcode);
        }

        public void Delete(int id)
        {
            var entity = _barcodeRepository.Get(id);
            if (entity != null)
            {
                _barcodeRepository.Delete(entity);
            }
        }
    }
}
