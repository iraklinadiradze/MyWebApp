using System;

namespace DataAccess
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
