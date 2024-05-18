using FastCell_DAL.Models.Entities;
using FC_DAL.Core.Generics.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCell_DAL.Core.Contracts
{
    public interface IManufacturerRepository : IGenericRepository<Manufacturer>
    {
    }
}
