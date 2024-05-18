using FastCell_DAL.Core.Contracts;
using FastCell_DAL.Models.Entities;
using FC_DAL.Core.Generics.GenericRepository;
using FC_DAL.Data;

namespace FastCell_DAL.Core.Repositories
{
    public class ProductModelRepository : GenericRepository<ProductModel>, IProductModelRepository
    {
        public ProductModelRepository(AppDbContext context) : base(context)
        {
        }
    }
}
