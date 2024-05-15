using FC_BAL.Services.Base.BaseService;
using FC_DAL.Core.Contracts;
using FC_DAL.Core.IConfiguration;
using FC_DAL.Models.Entities;

namespace FC_BAL.Services.ServicePriceService
{
    public class ServicePriceService : BaseService<ServicePrice>, IServicePriceService
    {
        public ServicePriceService(IUnitOfWork unitOfWork, IServicePriceRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}
