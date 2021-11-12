using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.GeneralLedger;


namespace Application.Domains.GeneralLedger.GlTransactionDetail.Queries.GetGlTransactionDetailList
{
    public class GlTransactionDetailView: DataAccessLayer.Model.GeneralLedger.GlTransactionDetail
    {

          public class _GlAccount
{
 public Int64 Id {get; set;} 
}

public class _GlTransaction
{
 public Int64 Id {get; set;} 
}

           public _GlAccount glAccount {get; set;} 

 public _GlTransaction glTransaction {get; set;} 

    }
}
