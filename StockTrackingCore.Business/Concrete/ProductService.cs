using StockTrackingCore.Business.Abstract;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace StockTrackingCore.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetAll()
        {
            return _productRepository.GetAll().ToList();
        }

        public IList<Product> GetAll(params string[] navigations)
        {
            return _productRepository.GetAll(navigations).ToList();
        }

        public Product Get(int id)
        {
            return _productRepository.Get(id);
        }

        public Product Get(int id, params string[] navigations)
        {
            return _productRepository.Get(id, navigations);
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Delete(int id)
        {

            var entity = _productRepository.Get(id);
            if (entity != null)
            {
                _productRepository.Delete(entity);
            }
        }
    }
}
