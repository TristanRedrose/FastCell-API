using FC_BAL.Services.Base.BaseService;
using FC_DAL.Core.Contracts;
using FC_DAL.Core.IConfiguration;
using FC_DAL.Models.Entities;

namespace FC_BAL.Services.ProductRepairService
{
    public class ProductRepairService : BaseService<ProductRepair>, IProductRepairService
    {
        public ProductRepairService(IUnitOfWork unitOfWork, IProductRepairRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}
