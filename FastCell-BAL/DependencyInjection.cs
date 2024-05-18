using FastCell_BAL.Services.AuthService;
using FastCell_BAL.Services.ManufacturerService;
using FastCell_BAL.Services.ProductModelService;
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
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IManufacturerService,ManufacturerService>();
            services.AddScoped<IProductModelService, ProductModelService>();

            return services;
        }
    }
}
