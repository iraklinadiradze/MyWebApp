using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Account;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Account.AccountDimension.Queries.GetAccountDimensionList
{

    public class GetAccountDimensionListQuery : IRequest<List<AccountDimensionView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
    }

    public class GetAccountDimensionListQueryHandler : IRequestHandler<GetAccountDimensionListQuery, List<AccountDimensionView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetAccountDimensionListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<AccountDimensionView>> Handle(GetAccountDimensionListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.AccountDimension
                        
                        select new AccountDimensionView
                           {
                             Id= e.Id,
Description= e.Description,
EntityId1= e.EntityId1,
EntityId2= e.EntityId2,
EntityId3= e.EntityId3,
EntityId4= e.EntityId4,
EntityId5= e.EntityId5,
EntityId6= e.EntityId6,
Name= e.Name
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

            return (List<AccountDimensionView>)await result.ToListAsync(cancellationToken);
        }

    }
}
