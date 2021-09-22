using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public string Password { get; set; }
        public DateTime? PwdLastChangeTime { get; set; }
        public bool? Active { get; set; }

        public virtual Group Group { get; set; }
    }
}
