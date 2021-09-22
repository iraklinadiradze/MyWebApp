using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class PermissionObject
    {
        public int PermissionObjectId { get; set; }
        public int PermissionId { get; set; }
        public string ObjectName { get; set; }
        public int? ObjectTypeId { get; set; }
        public string PermissionActionCode { get; set; }
        public int? ComponentId { get; set; }

        public virtual Component Component { get; set; }
        public virtual ObjectType ObjectType { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
