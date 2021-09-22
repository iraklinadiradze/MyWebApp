using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class PermissionCategory
    {
        public PermissionCategory()
        {
            PermissionGroups = new HashSet<PermissionGroup>();
        }

        public int PermissionCategoryId { get; set; }
        public string PermissionCategory1 { get; set; }
        public int? ModuleId { get; set; }

        public virtual Module Module { get; set; }
        public virtual ICollection<PermissionGroup> PermissionGroups { get; set; }
    }
}
