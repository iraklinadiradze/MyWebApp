using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Currency
    {
        public Currency()
        {
            Exrates = new HashSet<Exrate>();
            Purchases = new HashSet<Purchase>();
        }

        public int CurrencyId { get; set; }
        public string Currency1 { get; set; }
        public string CurrencyDescrip { get; set; }

        public virtual ICollection<Exrate> Exrates { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
