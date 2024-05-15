using System.ComponentModel.DataAnnotations;

namespace FC_DAL.Models.Entities
{
    public class ProductRepair
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
    }
}
