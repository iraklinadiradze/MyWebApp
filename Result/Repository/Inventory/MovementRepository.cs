using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Inventory;
using DataAccessLayer;

namespace WebAPI.Domains.Inventory.Data
{
    public class MovementRepository : Repository<Movement>, IMovementRepository
    {
        public MovementRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
