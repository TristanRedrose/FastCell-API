using FC_DAL.Core.Contracts;

namespace FC_DAL.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        ICellphoneRepository CellPhones{ get; }
        IProductRepairRepository RepairServices { get; }
        IServicePriceRepository ServicePrices { get; }
        Task CompleteAsync();
    }
}
