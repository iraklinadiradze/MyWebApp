using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Inventory;


namespace WebAPI.Domains.Inventory.Data
{
    public interface ILocationRepository: IRepository<Location>
    {
    
    }
}
