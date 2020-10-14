using StockTrackingCore.Business.Abstract;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace StockTrackingCore.Business.Concrete
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public IList<SubCategory> GetAll()
        {
            return _subCategoryRepository.GetAll().ToList();
        }

        public IList<SubCategory> GetAll(params string[] navigations)
        {
            return _subCategoryRepository.GetAll(navigations).ToList();
        }

        public SubCategory Get(int id)
        {
            return _subCategoryRepository.Get(id);
        }

        public SubCategory Get(int id, params string[] navigations)
        {
            return _subCategoryRepository.Get(id, navigations);
        }

        public void Add(SubCategory subCategory)
        {
            _subCategoryRepository.Add(subCategory);
        }

        public void Update(SubCategory subCategory)
        {
            _subCategoryRepository.Update(subCategory);
        }

        public void Delete(int id)
        {
            var entity = _subCategoryRepository.Get(id);
            if (entity != null)
            {
                _subCategoryRepository.Delete(entity);
            }
        }
    }
}
