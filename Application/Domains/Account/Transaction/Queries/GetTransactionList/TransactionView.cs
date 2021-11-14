using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Account;


namespace Application.Domains.Account.Transaction.Queries.GetTransactionList
{
    public class TransactionView: DataAccessLayer.Model.Account.Transaction
    {

          public class _Account
{
 public Int64 Id {get; set;} 
}

public class _TransactionOrder
{
 public Int64 Id {get; set;} 
}

           public _Account account {get; set;} 

 public _TransactionOrder transactionOrder {get; set;} 

    }
}
