using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SS.Data.Interfaces;

namespace SS.Data.Repos
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _context;
        public DataRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByName(string name)
        {
            return await _context.Set<TEntity>().FindAsync(name); // dunno if this works?
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.RemoveRange(entities);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool ContextUpdated()
        {
            var entityToUpdate = _context.ChangeTracker.Entries()
                        .Where(e => e.State != EntityState.Unchanged)
                        .FirstOrDefault();

            if (entityToUpdate == null)
            {
                return false;
            }

            return true;
        }
    }
}