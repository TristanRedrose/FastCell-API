using FastCell.Controllers.BaseController;
using FC_BAL.Services.CellPhoneService;
using FC_DAL.Models.Entities;

namespace FastCell.Controllers.Controllers
{
    public class PhoneController : BaseController<CellPhone>
    {
        public PhoneController(ICellPhoneService service) : base(service)
        {
        }
    }
}
