using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Core;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Core.Entity.Queries.GetEntityList
{

    public class GetEntityListQuery : IRequest<List<EntityView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
    }

    public class GetEntityListQueryHandler : IRequestHandler<GetEntityListQuery, List<EntityView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetEntityListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<EntityView>> Handle(GetEntityListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.Entity
                        
                        select new EntityView
                           {
                             Id= e.Id,
EntityCode= e.EntityCode,
EntityDescription= e.EntityDescription,
EntityName= e.EntityName
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

            return (List<EntityView>)await result.ToListAsync(cancellationToken);
        }

    }
}
