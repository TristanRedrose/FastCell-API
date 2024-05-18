using FastCell.Controllers.BaseController;
using FastCell_BAL.Services.ProductModelService;
using FastCell_DAL.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace FastCell.Controllers.Controllers
{
    [Authorize(Policy = "RequireEmployeeAccess")]
    public class ProductModelController : BaseController<ProductModel>
    {
        public ProductModelController(IProductModelService service) : base(service)
        {
        }
    }
}
