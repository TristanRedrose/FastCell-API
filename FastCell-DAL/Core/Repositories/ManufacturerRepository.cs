using FastCell_DAL.Core.Contracts;
using FastCell_DAL.Models.Entities;
using FC_DAL.Core.Generics.GenericRepository;
using FC_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCell_DAL.Core.Repositories
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
