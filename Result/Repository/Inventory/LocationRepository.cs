using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Inventory;
using DataAccessLayer;

namespace WebAPI.Domains.Inventory.Data
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
