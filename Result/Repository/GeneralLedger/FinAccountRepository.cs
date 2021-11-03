using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.GeneralLedger;
using DataAccessLayer;

namespace WebAPI.Domains.GeneralLedger.Data
{
    public class FinAccountRepository : Repository<FinAccount>, IFinAccountRepository
    {
        public FinAccountRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
