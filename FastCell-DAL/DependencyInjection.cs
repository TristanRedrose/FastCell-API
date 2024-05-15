using FC_DAL.Core.Contracts;
using FC_DAL.Core.IConfiguration;
using FC_DAL.Core.Repositories;
using FC_DAL.Data;
using Microsoft.Extensions.DependencyInjection;

namespace FC_DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICellphoneRepository, CellPhoneRepository>();
            services.AddScoped<IProductRepairRepository, ProductRepairRepository>();
            services.AddScoped<IServicePriceRepository, ServicePriceRepository>();

            return services;
        }
    }
}
