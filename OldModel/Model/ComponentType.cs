using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ComponentType
    {
        public ComponentType()
        {
            Components = new HashSet<Component>();
        }

        public int ComponentTypeId { get; set; }
        public string ComponentType1 { get; set; }

        public virtual ICollection<Component> Components { get; set; }
    }
}
