using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Module
    {
        public Module()
        {
            PermissionCategories = new HashSet<PermissionCategory>();
        }

        public int ModuleId { get; set; }
        public string ModuleName { get; set; }

        public virtual ICollection<PermissionCategory> PermissionCategories { get; set; }
    }
}
