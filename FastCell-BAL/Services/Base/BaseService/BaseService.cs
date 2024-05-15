using FC_BAL.Services.Base.IBaseService;
using FC_DAL.Core.Generics.IGenericRepository;
using FC_DAL.Core.IConfiguration;

namespace FC_BAL.Services.Base.BaseService
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IGenericRepository<TEntity> _repository;

        public BaseService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            var result = await _repository.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result =  await _repository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return result;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> UpsertAsync(TEntity entity)
        {
            var result = await _repository.UpsertAsync(entity);
            await _unitOfWork.CompleteAsync();
            return result;
        }
    }
}
