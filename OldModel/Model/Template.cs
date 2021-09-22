using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Template
    {
        public Template()
        {
            Productions = new HashSet<Production>();
            TemplateIns = new HashSet<TemplateIn>();
            TemplateOuts = new HashSet<TemplateOut>();
        }

        public long TemplateId { get; set; }
        public int ProductionTypeId { get; set; }
        public string TemplateName { get; set; }
        public bool? Posted { get; set; }

        public virtual ICollection<Production> Productions { get; set; }
        public virtual ICollection<TemplateIn> TemplateIns { get; set; }
        public virtual ICollection<TemplateOut> TemplateOuts { get; set; }
    }
}
