using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Permission
    {
        public Permission()
        {
            GroupPermissions = new HashSet<GroupPermission>();
            PermissionObjects = new HashSet<PermissionObject>();
        }

        public int PermissionId { get; set; }
        public string PermissionCode { get; set; }
        public string PermissionName { get; set; }
        public int? PermissionGroupId { get; set; }

        public virtual PermissionGroup PermissionGroup { get; set; }
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
        public virtual ICollection<PermissionObject> PermissionObjects { get; set; }
    }
}
