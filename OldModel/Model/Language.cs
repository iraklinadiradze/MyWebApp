using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Language
    {
        public Language()
        {
            ErrorCodeLanguages = new HashSet<ErrorCodeLanguage>();
        }

        public int LanguageId { get; set; }
        public string Lang { get; set; }
        public string Language1 { get; set; }

        public virtual ICollection<ErrorCodeLanguage> ErrorCodeLanguages { get; set; }
    }
}
