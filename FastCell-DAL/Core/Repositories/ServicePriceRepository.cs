using FC_DAL.Core.Contracts;
using FC_DAL.Core.Generics.GenericRepository;
using FC_DAL.Data;
using FC_DAL.Models.Entities;

namespace FC_DAL.Core.Repositories
{
    public class ServicePriceRepository : GenericRepository<ServicePrice>, IServicePriceRepository
    {
        public ServicePriceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
