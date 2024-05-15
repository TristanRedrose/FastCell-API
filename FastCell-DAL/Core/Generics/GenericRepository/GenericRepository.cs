using System;
using FC_DAL.Core.Generics.IGenericRepository;
using FC_DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace FC_DAL.Core.Generics.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected AppDbContext _context;
        protected DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var item = await _dbSet.FindAsync(id);

            if (item != null)
            {
                _dbSet.Remove(item);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> UpsertAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return true;
        }
    }
}

