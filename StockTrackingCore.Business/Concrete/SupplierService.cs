using StockTrackingCore.Business.Abstract;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace StockTrackingCore.Business.Concrete
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public void Add(Supplier supplier)
        {
            _supplierRepository.Add(supplier);
        }

        public void Delete(int id)
        {
            var entity = _supplierRepository.Get(id);
            if (entity != null)
            {
                _supplierRepository.Delete(entity);
            }
        }

        public void DeleteSelected(List<int> ids)
        {
            var entity = _supplierRepository.GetAll().Where(x => ids.Contains(x.Id)).ToList();
            if (entity.Count > 0)
            {
                _supplierRepository.DeleteSelected(entity);
            }
        }

        public Supplier Get(int id)
        {
            return _supplierRepository.Get(id);
        }

        public Supplier Get(int id, params string[] navigations)
        {
            return _supplierRepository.Get(id, navigations);
        }

        public IList<Supplier> GetAll()
        {
            return _supplierRepository.GetAll().ToList();
        }

        public IList<Supplier> GetAll(params string[] navigations)
        {
            return _supplierRepository.GetAll(navigations).ToList();
        }

        public void Update(Supplier supplier)
        {
            _supplierRepository.Update(supplier);
        }
    }
}
