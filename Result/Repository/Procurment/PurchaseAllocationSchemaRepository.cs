using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Procurment;
using DataAccessLayer;

namespace WebAPI.Domains.Procurment.Data
{
    public class PurchaseAllocationSchemaRepository : Repository<PurchaseAllocationSchema>, IPurchaseAllocationSchemaRepository
    {
        public PurchaseAllocationSchemaRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
