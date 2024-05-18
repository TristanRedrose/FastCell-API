namespace FastCell_DAL.Models.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductModel> ProductModels { get; set; } = new List<ProductModel>();
    }
}
