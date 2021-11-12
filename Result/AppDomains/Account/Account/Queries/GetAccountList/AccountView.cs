using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Account;


namespace Application.Domains.Account.Account.Queries.GetAccountList
{
    public class AccountView: DataAccessLayer.Model.Account.Account
    {

          public class _AccountDimension
{
 public Int32 Id {get; set;} 
}

           public _AccountDimension accountDimension {get; set;} 

    }
}
