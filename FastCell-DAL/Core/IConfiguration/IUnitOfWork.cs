using FastCell_DAL.Core.Contracts;
using FC_DAL.Core.Contracts;

namespace FC_DAL.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        ICellphoneRepository CellPhones{ get; }
        IProductRepairRepository RepairServices { get; }
        IServicePriceRepository ServicePrices { get; }
        IProductModelRepository ProductModels { get; }
        IManufacturerRepository Manufacturers { get; }
        Task CompleteAsync();
    }
}
