using System.ComponentModel.DataAnnotations.Schema;

namespace FC_DAL.Models.Entities
{
    public class ServicePrice
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public Guid PhoneId { get; set; }
        public CellPhone CellPhone { get; set; } = null!;
        public Guid ServiceId { get; set; }
        public ProductRepair RepairService { get; set; } = null!;
    }
}
