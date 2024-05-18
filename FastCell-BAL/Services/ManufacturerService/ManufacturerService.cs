using FastCell_DAL.Core.Contracts;
using FastCell_DAL.Models.Entities;
using FC_BAL.Services.Base.BaseService;
using FC_DAL.Core.IConfiguration;

namespace FastCell_BAL.Services.ManufacturerService
{
    public class ManufacturerService : BaseService<Manufacturer>, IManufacturerService
    {
        public ManufacturerService(IUnitOfWork unitOfWork, IManufacturerRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}
