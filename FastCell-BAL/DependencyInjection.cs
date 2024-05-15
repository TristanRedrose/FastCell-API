using FC_BAL.Services.CellPhoneService;
using FC_BAL.Services.ProductRepairService;
using FC_BAL.Services.ServicePriceService;
using Microsoft.Extensions.DependencyInjection;

namespace FC_BAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessAccess(this IServiceCollection services)
        {
            services.AddScoped<ICellPhoneService, CellPhoneService>();
            services.AddScoped<IProductRepairService, ProductRepairService>();
            services.AddScoped<IServicePriceService, ServicePriceService>();

            return services;
        }
    }
}
