using StockTrackingCore.Business.Abstract;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace StockTrackingCore.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IList<Category> GetAll()
        {
            return _categoryRepository.GetAll().ToList();
        }

        public IList<Category> GetAll(params string[] navigations)
        {
            return _categoryRepository.GetAll(navigations).ToList();
        }

        public Category Get(int id)
        {
            return _categoryRepository.Get(id);
        }

        public Category Get(int id, params string[] navigations)
        {
            return _categoryRepository.Get(id, navigations);
        }

        public void Add(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }

        public void Delete(int id)
        {
            var entity = _categoryRepository.Get(id);
            if (entity != null)
            {
                _categoryRepository.Delete(entity);
            }
        }
    }
}
