using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Models;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using API_LuisaBot.Repositories.Context;

namespace API_LuisaBot.Repositories.ConcreteRepositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected AppDbContext _context = null;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        #region Public Methods

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => _context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task Add(T entity)
        {
            // await _context.AddAsync(entity);
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            // In case AsNoTracking is used
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => _context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => _context.Set<T>().CountAsync(predicate);

        #endregion
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
