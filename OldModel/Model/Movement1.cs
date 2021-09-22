using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Movement1
    {
        public Movement1()
        {
            MovementDetails = new HashSet<MovementDetail>();
        }

        public long MovementId { get; set; }
        public DateTime FromTransDate { get; set; }
        public DateTime ToTransDate { get; set; }
        public int? FromLocationId { get; set; }
        public int? ToLocationId { get; set; }
        public bool? FromQtyPostedStarted { get; set; }
        public bool? FromFinPostedStarted { get; set; }
        public bool? ToQtyPostedStarted { get; set; }
        public bool? ToFinPostedStarted { get; set; }
        public bool? FromQtyPosted { get; set; }
        public bool? FromFinPosted { get; set; }
        public bool? ToFinPosted { get; set; }
        public bool? ToQtyPosted { get; set; }
        public int FromPosted { get; set; }
        public int ToPosted { get; set; }

        public virtual ICollection<MovementDetail> MovementDetails { get; set; }
    }
}
