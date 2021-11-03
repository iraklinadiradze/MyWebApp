using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Product;
using DataAccessLayer;

namespace WebAPI.Domains.Product.Data
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
