using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Group
    {
        public Group()
        {
            GroupPermissions = new HashSet<GroupPermission>();
            Users = new HashSet<User>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
