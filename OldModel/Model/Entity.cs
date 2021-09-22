using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Entity
    {
        public Entity()
        {
            AccountDimensionEntityId1Navigations = new HashSet<AccountDimension>();
            AccountDimensionEntityId2Navigations = new HashSet<AccountDimension>();
            AccountDimensionEntityId3Navigations = new HashSet<AccountDimension>();
            AccountDimensionEntityId4Navigations = new HashSet<AccountDimension>();
            AccountDimensionEntityId5Navigations = new HashSet<AccountDimension>();
            AccountDimensionEntityId6Navigations = new HashSet<AccountDimension>();
        }

        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public string EntityCode { get; set; }
        public string EntityDescrip { get; set; }

        public virtual ICollection<AccountDimension> AccountDimensionEntityId1Navigations { get; set; }
        public virtual ICollection<AccountDimension> AccountDimensionEntityId2Navigations { get; set; }
        public virtual ICollection<AccountDimension> AccountDimensionEntityId3Navigations { get; set; }
        public virtual ICollection<AccountDimension> AccountDimensionEntityId4Navigations { get; set; }
        public virtual ICollection<AccountDimension> AccountDimensionEntityId5Navigations { get; set; }
        public virtual ICollection<AccountDimension> AccountDimensionEntityId6Navigations { get; set; }
    }
}
