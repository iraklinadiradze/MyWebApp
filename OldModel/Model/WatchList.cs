using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class WatchList
    {
        public long WatchListId { get; set; }
        public int EntityId { get; set; }
        public long EntityForeignId { get; set; }
        public int WatchedEntityId { get; set; }
        public long WatchedEntityForeignId { get; set; }
    }
}
