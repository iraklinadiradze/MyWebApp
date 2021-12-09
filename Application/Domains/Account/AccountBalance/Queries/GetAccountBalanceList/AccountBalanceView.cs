using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Account;


namespace Application.Domains.Account.AccountBalance.Queries.GetAccountBalanceList
{
    public class AccountBalanceView: Application.Model.Account.AccountBalance
    {

          public class _Account
{
 public Int64 Id {get; set;} 
}

           public _Account account {get; set;} 

    }
}
