using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.GeneralLedger;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.GeneralLedger.GlAccount.Queries.GetGlAccountList
{

    public class GetGlAccountListQuery : IRequest<List<GlAccountView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int64? Id {get;set;}
    }

    public class GetGlAccountListQueryHandler : IRequestHandler<GetGlAccountListQuery, List<GlAccountView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetGlAccountListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<GlAccountView>> Handle(GetGlAccountListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.GlAccount
                         join _finAccount in _context.FinAccount on e.FinAccountId equals _finAccount.Id into __finAccount
 from _finAccount in __finAccount.DefaultIfEmpty()
                        select new GlAccountView
                           {
                             Id= e.Id,
AccountCode= e.AccountCode,
Description= e.Description,
FinAccountId= e.FinAccountId,
Name= e.Name,
finAccount = new GlAccountView._FinAccount{
Id= _finAccount.Id
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<GlAccountView>)await result.ToListAsync(cancellationToken);
        }

    }
}
