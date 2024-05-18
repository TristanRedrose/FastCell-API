using FastCell.Controllers.BaseController;
using FastCell_BAL.Services.ManufacturerService;
using FastCell_DAL.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace FastCell.Controllers.Controllers
{
    [Authorize(Policy = "RequireAdministratorAccess")]
    public class ManufacturerController : BaseController<Manufacturer>
    {
       
        public ManufacturerController(IManufacturerService service) : base(service)
        {
        }
    }
}
