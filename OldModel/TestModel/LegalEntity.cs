using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.TestModel
{
    public partial class LegalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxCode { get; set; }
        public DateTime? RegDate { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public virtual Client Client { get; set; }
    }
}
