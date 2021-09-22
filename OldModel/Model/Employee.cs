using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Employee
    {
        public Employee()
        {
            ShopEmployees = new HashSet<ShopEmployee>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? UserRoleId { get; set; }

        public virtual ICollection<ShopEmployee> ShopEmployees { get; set; }
    }
}
