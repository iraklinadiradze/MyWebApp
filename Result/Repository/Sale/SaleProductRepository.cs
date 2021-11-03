using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Sale;
using DataAccessLayer;

namespace WebAPI.Domains.Sale.Data
{
    public class SaleProductRepository : Repository<SaleProduct>, ISaleProductRepository
    {
        public SaleProductRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
