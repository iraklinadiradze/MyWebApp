using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer
{
    public partial class ClientType
    {
        public ClientType()
        {
            Client = new HashSet<Client>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        [LookupDisplayAttribute]
        [FilterParam(equals=true)]
        [MaxLength(30)]
        public string ClientTypeName { get; set; }

        public virtual ICollection<Client> Client { get; set; }
    }
}
