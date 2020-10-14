using StockTrackingCore.Entities.Abstract;
using StockTrackingCore.Entities.Concrete;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace StockTrackingCore.DataAccess.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity, IEntity
    {
        T Get(int id);
        T Get(int id, params string[] navigations);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params string[] navigations);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
