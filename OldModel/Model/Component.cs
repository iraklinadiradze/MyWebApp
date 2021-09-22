using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Component
    {
        public Component()
        {
            PermissionObjects = new HashSet<PermissionObject>();
        }

        public int ComponentId { get; set; }
        public string ComponentName { get; set; }
        public int ComponentTypeId { get; set; }

        public virtual ComponentType ComponentType { get; set; }
        public virtual ICollection<PermissionObject> PermissionObjects { get; set; }
    }
}
