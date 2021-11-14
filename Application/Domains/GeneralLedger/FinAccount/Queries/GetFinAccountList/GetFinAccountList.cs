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

namespace Application.Domains.GeneralLedger.FinAccount.Queries.GetFinAccountList
{

    public class GetFinAccountListQuery : IRequest<List<FinAccountView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetFinAccountListQueryHandler : IRequestHandler<GetFinAccountListQuery, List<FinAccountView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetFinAccountListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<FinAccountView>> Handle(GetFinAccountListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.FinAccount
                        
                        select new FinAccountView
                           {
                             Id= e.Id,
Description= e.Description,
FinAccountCode= e.FinAccountCode,
Name= e.Name
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<FinAccountView>)await result.ToListAsync(cancellationToken);
        }

    }
}
