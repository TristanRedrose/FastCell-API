using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCell_DAL.Models.Entities
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
