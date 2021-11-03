using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Core;
using DataAccessLayer;

namespace WebAPI.Domains.Core.Data
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
