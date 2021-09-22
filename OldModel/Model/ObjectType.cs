using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ObjectType
    {
        public ObjectType()
        {
            PermissionObjects = new HashSet<PermissionObject>();
        }

        public int ObjectTypeId { get; set; }
        public string ObjectType1 { get; set; }

        public virtual ICollection<PermissionObject> PermissionObjects { get; set; }
    }
}
