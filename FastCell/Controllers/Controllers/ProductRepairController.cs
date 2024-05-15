using FastCell.Controllers.BaseController;
using FC_BAL.Services.ProductRepairService;
using FC_DAL.Models.Entities;

namespace FastCell.Controllers.Controllers
{
    public class ProductRepairController : BaseController<ProductRepair>
    {
        public ProductRepairController(IProductRepairService service) : base(service)
        {
        }
    }
}
