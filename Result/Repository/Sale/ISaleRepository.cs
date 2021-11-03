using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Sale;


namespace WebAPI.Domains.Sale.Data
{
    public interface ISaleRepository: IRepository<Sale>
    {
    
    }
}
