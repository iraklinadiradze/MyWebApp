using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Account;
using DataAccessLayer;

namespace WebAPI.Domains.Account.Data
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
