using FastCell_DAL.Models.Entities;

namespace FC_DAL.Models.Entities
{
    public class CellPhone
    {
        public Guid Id { get; set; }
        public int ProductModelId { get; set; }
        public ProductModel ProductModel { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
