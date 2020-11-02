using StockTrackingCore.Business.Abstract;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace StockTrackingCore.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void Add(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public void Delete(int id)
        {
            var entity = _customerRepository.Get(id);
            if (entity != null)
            {
                _customerRepository.Delete(entity);
            }
        }

        public void DeleteSelected(List<int> ids)
        {
            var entity = _customerRepository.GetAll().Where(x => ids.Contains(x.Id)).ToList();
            if (entity.Count > 0)
            {
                _customerRepository.DeleteSelected(entity);
            }
        }

        public Customer Get(int id)
        {
            return _customerRepository.Get(id);
        }

        public Customer Get(int id, params string[] navigations)
        {
            return _customerRepository.Get(id, navigations);
        }

        public IList<Customer> GetAll()
        {
            return _customerRepository.GetAll().ToList();
        }

        public IList<Customer> GetAll(params string[] navigations)
        {
            return _customerRepository.GetAll(navigations).ToList();
        }

        public void Update(Customer customer)
        {
            _customerRepository.Update(customer);
        }
    }
}
