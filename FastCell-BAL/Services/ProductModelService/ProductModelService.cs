using FastCell_DAL.Core.Contracts;
using FastCell_DAL.Models.Entities;
using FC_BAL.Services.Base.BaseService;
using FC_DAL.Core.IConfiguration;

namespace FastCell_BAL.Services.ProductModelService
{
    internal class ProductModelService : BaseService<ProductModel>, IProductModelService
    {
        public ProductModelService(IUnitOfWork unitOfWork, IProductModelRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}
