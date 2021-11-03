using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Core;


namespace WebAPI.Domains.Core.Data
{
    public interface ICountryRepository: IRepository<Country>
    {
    
    }
}
