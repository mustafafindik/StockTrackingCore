using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;

namespace StockTrackingCore.Business.Abstract
{
    public interface ICustomerService
    {
        IList<Customer> GetAll();
        IList<Customer> GetAll(params string[] navigations);
        Customer Get(int id);
        Customer Get(int id, params string[] navigations);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
        void DeleteSelected(List<int> ids);
    }
}
