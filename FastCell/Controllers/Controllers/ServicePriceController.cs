using FastCell.Controllers.BaseController;
using FC_BAL.Services.ServicePriceService;
using FC_DAL.Models.Entities;

namespace FastCell.Controllers.Controllers
{
    public class ServicePriceController : BaseController<ServicePrice>
    {
        public ServicePriceController(IServicePriceService service) : base(service)
        {
        }
    }
}
