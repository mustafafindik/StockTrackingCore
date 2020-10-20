using StockTrackingCore.Business.Abstract;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace StockTrackingCore.Business.Concrete
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public IList<Warehouse> GetAll()
        {
            return _warehouseRepository.GetAll().ToList();
        }

        public IList<Warehouse> GetAll(params string[] navigations)
        {
            return _warehouseRepository.GetAll(navigations).ToList();
        }

        public Warehouse Get(int id)
        {
            return _warehouseRepository.Get(id);
        }

        public Warehouse Get(int id, params string[] navigations)
        {
            return _warehouseRepository.Get(id, navigations);
        }

        public void Add(Warehouse warehouse)
        {
            _warehouseRepository.Add(warehouse);
        }

        public void Update(Warehouse warehouse)
        {
            _warehouseRepository.Update(warehouse);
        }

        public void Delete(int id)
        {
            var entity = _warehouseRepository.Get(id);
            if (entity != null)
            {
                _warehouseRepository.Delete(entity);
            }
        }

        public void DeleteSelected(List<int> ids)
        {
            var entity = _warehouseRepository.GetAll().Where(x => ids.Contains(x.Id)).ToList();
            if (entity.Count > 0)
            {
                _warehouseRepository.DeleteSelected(entity);
            }
        }
    }
}
