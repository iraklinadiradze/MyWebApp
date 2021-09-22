using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            B2pTransactions = new HashSet<B2pTransaction>();
        }

        public int DocumentTypeId { get; set; }
        public string DocumentType1 { get; set; }

        public virtual ICollection<B2pTransaction> B2pTransactions { get; set; }
    }
}
