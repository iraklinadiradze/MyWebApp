using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Client
    {
        public long ClientId { get; set; }
        public bool? IsPerson { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string ClientName { get; set; }
        public string PresonalId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string TaxCode { get; set; }
        public DateTime? TaxRegDate { get; set; }
        public string LegalAddress { get; set; } 
        public string ActualAddress { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool? IsEmployee { get; set; }
        public bool? IsSupplier { get; set; }
        public bool? IsCustomer { get; set; }
        public bool? IsBank { get; set; }
    }
}
