using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Core;
using DataAccessLayer;

namespace WebAPI.Domains.Core.Data
{
    public class EntityRepository : Repository<Entity>, IEntityRepository
    {
        public EntityRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
