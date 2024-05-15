using System;


namespace FC_DAL.Core.Generics.IGenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpsertAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
    } 
}


