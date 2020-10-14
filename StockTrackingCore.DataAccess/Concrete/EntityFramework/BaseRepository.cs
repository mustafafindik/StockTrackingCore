using Microsoft.EntityFrameworkCore;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.DataAccess.Concrete.EntityFramework.Contexts;
using StockTrackingCore.Entities.Abstract;
using StockTrackingCore.Entities.Concrete;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace StockTrackingCore.DataAccess.Concrete.EntityFramework
{


    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, IEntity
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T Get(int id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public T Get(int id, params string[] navigations)
        {

            var query = _context.Set<T>().AsNoTracking().AsQueryable();
            foreach (var nav in navigations)
            {
                query = query.Include(nav);
            }
            return query.FirstOrDefault(e => e.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> GetAll(params string[] navigations)
        {

            var query = _context.Set<T>().AsNoTracking().AsQueryable();
            foreach (var nav in navigations)
            {
                query = query.Include(nav);
            }
            return query;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();

        }
    }
}
