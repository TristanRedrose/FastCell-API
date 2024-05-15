namespace FC_DAL.Models.Entities
{
    public class CellPhone
    {
        public Guid Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
