using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Account;
using DataAccessLayer;

namespace WebAPI.Domains.Account.Data
{
    public class AccountBalanceRepository : Repository<AccountBalance>, IAccountBalanceRepository
    {
        public AccountBalanceRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
