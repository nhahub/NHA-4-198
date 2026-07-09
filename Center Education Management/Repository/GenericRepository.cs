using Center_Education_Management.EFcore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Center_Education_Management.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CenterDBContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(CenterDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // ------------------- Read -------------------
        public T? GetById(int id) => _dbSet.Find(id);

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
            => _dbSet.Where(predicate).ToList();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        public T? FirstOrDefault(Expression<Func<T, bool>> predicate)
            => _dbSet.FirstOrDefault(predicate);

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.FirstOrDefaultAsync(predicate);

        public bool Any(Expression<Func<T, bool>> predicate) => _dbSet.Any(predicate);

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.AnyAsync(predicate);

        public int Count(Expression<Func<T, bool>>? predicate = null)
            => predicate == null ? _dbSet.Count() : _dbSet.Count(predicate);

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
            => predicate == null ? await _dbSet.CountAsync() : await _dbSet.CountAsync(predicate);

        public IQueryable<T> GetQueryable() => _dbSet.AsQueryable();

        // ------------------- Write -------------------
        public void Add(T entity) => _dbSet.Add(entity);

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void AddRange(IEnumerable<T> entities) => _dbSet.AddRange(entities);

        public async Task AddRangeAsync(IEnumerable<T> entities) => await _dbSet.AddRangeAsync(entities);

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities) => _dbSet.UpdateRange(entities);

        public void Remove(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);

        public void RemoveById(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
                Remove(entity);
        }
    }
}
