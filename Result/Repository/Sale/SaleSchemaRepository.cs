using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Sale;
using DataAccessLayer;

namespace WebAPI.Domains.Sale.Data
{
    public class SaleSchemaRepository : Repository<SaleSchema>, ISaleSchemaRepository
    {
        public SaleSchemaRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
