namespace FC_BAL.Services.Base.IBaseService
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<bool>AddAsync(TEntity entity);
        Task<bool> UpsertAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
