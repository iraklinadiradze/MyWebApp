using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.SeedWork;
using DataAccessLayer.Model.Client;
using DataAccessLayer;

namespace WebAPI.Domains.Client.Data
{
    public class LegalEntityRepository : Repository<LegalEntity>, ILegalEntityRepository
    {
        public LegalEntityRepository(CoreDBContext _coreDbContext) : base(_coreDbContext)
        {

        }

    }
}
