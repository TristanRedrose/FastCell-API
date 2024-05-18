using FastCell_DAL.Enums;

namespace FastCell_DAL.Models.Entities.Auth.Info
{
    public class EmployeeInfo
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public bool Active { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public int Salary { get; set; }
    }
}
