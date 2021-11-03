using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Account;


namespace WebAPI.Domains.Account.Data
{
    public interface IAccountRepository: IRepository<Account>
    {
    
    }
}
