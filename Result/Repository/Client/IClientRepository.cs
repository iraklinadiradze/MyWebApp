using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Client;


namespace WebAPI.Domains.Client.Data
{
    public interface IClientRepository: IRepository<Client>
    {
    
    }
}
