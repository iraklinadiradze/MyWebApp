using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Exrate
    {
        public int ExrateId { get; set; }
        public DateTime TransDate { get; set; }
        public int CurrencyId { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
