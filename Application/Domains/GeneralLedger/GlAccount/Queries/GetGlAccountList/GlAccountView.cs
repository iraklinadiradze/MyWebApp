using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.GeneralLedger;


namespace Application.Domains.GeneralLedger.GlAccount.Queries.GetGlAccountList
{
    public class GlAccountView: Application.Model.GeneralLedger.GlAccount
    {

          public class _FinAccount
{
 public Int32 Id {get; set;} 
}

           public _FinAccount finAccount {get; set;} 

    }
}
