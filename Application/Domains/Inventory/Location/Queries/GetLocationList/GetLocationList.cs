using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Inventory;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Inventory.Location.Queries.GetLocationList
{

    public class GetLocationListQuery : IRequest<List<LocationView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
public String Name {get;set;}
    }

    public class GetLocationListQueryHandler : IRequestHandler<GetLocationListQuery, List<LocationView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetLocationListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<LocationView>> Handle(GetLocationListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.Location
                        
                        select new LocationView
                           {
                             Id= e.Id,
Name= e.Name
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

                if (request.Name!= null) 
 result = result.Where(r => r.Name.StartsWith(request.Name));

            return (List<LocationView>)await result.ToListAsync(cancellationToken);
        }

    }
}
