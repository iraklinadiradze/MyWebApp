using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Payments = new HashSet<Payment>();
        }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
