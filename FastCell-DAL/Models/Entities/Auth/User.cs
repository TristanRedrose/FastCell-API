using FastCell_DAL.Models.Entities.Auth.Info;
using Microsoft.AspNetCore.Identity;

namespace FastCell_DAL.Models.Entities.Auth
{
    public class User : IdentityUser
    {
        public int ContactInfoId { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public int? EmployeeInfoId { get; set; }
        public EmployeeInfo? EmployeeInfo { get; set; }
    }
}
