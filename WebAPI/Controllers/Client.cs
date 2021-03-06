using System;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPI.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public int? ClientTypeId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }

        public virtual ClientType ClientType { get; set; }
    }
}
