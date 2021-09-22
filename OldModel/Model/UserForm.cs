using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class UserForm
    {
        public int UserFormId { get; set; }
        public int? UserId { get; set; }
        public int? FormId { get; set; }
        public string ControlDefaults { get; set; }
        public string FormLayout { get; set; }

        public virtual Form Form { get; set; }
    }
}
