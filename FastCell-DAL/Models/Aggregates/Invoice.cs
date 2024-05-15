using FC_DAL.Models.Entities;

namespace FC_DAL.Models.Aggregates
{
    public class Invoice
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public ServicePrice ServiceInfo { get; set; }

    }
}
