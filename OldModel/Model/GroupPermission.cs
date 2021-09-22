using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class GroupPermission
    {
        public int GroupPermissionId { get; set; }
        public int GroupId { get; set; }
        public int PermissionId { get; set; }
        public bool? Enabled { get; set; }

        public virtual Group Group { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
