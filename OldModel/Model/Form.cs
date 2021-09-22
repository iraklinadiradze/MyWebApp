using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Form
    {
        public Form()
        {
            UserForms = new HashSet<UserForm>();
        }

        public int FormId { get; set; }
        public string FormName { get; set; }
        public string Descrip { get; set; }
        public string ControlDefaults { get; set; }
        public string FormLayout { get; set; }

        public virtual ICollection<UserForm> UserForms { get; set; }
    }
}
