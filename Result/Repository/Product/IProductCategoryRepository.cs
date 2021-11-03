using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Product;


namespace WebAPI.Domains.Product.Data
{
    public interface IProductCategoryRepository: IRepository<ProductCategory>
    {
    
    }
}
