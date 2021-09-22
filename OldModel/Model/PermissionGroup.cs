using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class PermissionGroup
    {
        public PermissionGroup()
        {
            Permissions = new HashSet<Permission>();
        }

        public int PermissionGroupId { get; set; }
        public string PermissionGroupCode { get; set; }
        public int? PermissionCategoryId { get; set; }

        public virtual PermissionCategory PermissionCategory { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
