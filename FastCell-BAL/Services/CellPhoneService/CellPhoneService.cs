using FC_BAL.Services.Base.BaseService;
using FC_DAL.Core.Contracts;
using FC_DAL.Core.IConfiguration;
using FC_DAL.Models.Entities;

namespace FC_BAL.Services.CellPhoneService
{
    public class CellPhoneService : BaseService<CellPhone>, ICellPhoneService
    {
        public CellPhoneService(IUnitOfWork unitOfWork, ICellphoneRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}
