using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.GeneralLedger;


namespace Application.Domains.GeneralLedger.GlAccount.Queries.GetGlAccountList
{
    public class GlAccountView: DataAccessLayer.Model.GeneralLedger.GlAccount
    {

          public class _FinAccount
{
 public Int32 Id {get; set;} 
}

           public _FinAccount finAccount {get; set;} 

    }
}
