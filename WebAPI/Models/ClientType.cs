using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPI.Models
{
    public partial class ClientType
    {
        public ClientType()
        {
            Client = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string ClientTypeName { get; set; }

        public virtual ICollection<Client> Client { get; set; }
    }
}
