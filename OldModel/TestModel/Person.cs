using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.TestModel
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Pid { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public virtual Client Client { get; set; }
    }
}
