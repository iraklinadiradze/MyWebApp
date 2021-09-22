using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.TestModel
{
    public partial class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsPerson { get; set; }

        public virtual Person Id1 { get; set; }
        public virtual LegalEntity IdNavigation { get; set; }
    }
}
