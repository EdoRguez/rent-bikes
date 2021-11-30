using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            if (trackChanges)
                return _context.Set<T>();

            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            if (trackChanges)
                return _context.Set<T>().Where(expression);

            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task<T> FindSingleByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            if(trackChanges)
                return await _context.Set<T>().SingleOrDefaultAsync(expression);

            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(expression);
        }

        public bool CheckAnyByCondition(Expression<Func<T, bool>> expression)
        {          
            return _context.Set<T>().Any(expression);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
