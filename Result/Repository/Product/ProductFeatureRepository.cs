using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Product;
using DataAccessLayer;

namespace WebAPI.Domains.Product.Data
{
    public class ProductFeatureRepository : Repository<ProductFeature>, IProductFeatureRepository
    {
        public ProductFeatureRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
