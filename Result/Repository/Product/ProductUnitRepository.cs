using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Product;
using DataAccessLayer;

namespace WebAPI.Domains.Product.Data
{
    public class ProductUnitRepository : Repository<ProductUnit>, IProductUnitRepository
    {
        public ProductUnitRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
