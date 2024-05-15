using FC_DAL.Core.Contracts;
using FC_DAL.Core.IConfiguration;
using FC_DAL.Core.Repositories;

namespace FC_DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICellphoneRepository CellPhones {  get; private set; }
        public IProductRepairRepository RepairServices { get; private set; }
        public IServicePriceRepository ServicePrices {  get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            CellPhones = new CellPhoneRepository(context);
            RepairServices = new ProductRepairRepository(context);
            ServicePrices = new ServicePriceRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }
    }
}
