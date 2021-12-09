using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Core;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Core.Country.Queries.GetCountryList
{

    public class GetCountryListQuery : IRequest<List<CountryView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
public String Code {get;set;}
public String Name {get;set;}
    }

    public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, List<CountryView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetCountryListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<CountryView>> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.Country
                        
                        select new CountryView
                           {
                             Id= e.Id,
Code= e.Code,
Name= e.Name
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

                if (request.Code!= null) 
 result = result.Where(r => r.Code== request.Code);

                if (request.Name!= null) 
 result = result.Where(r => r.Name.StartsWith(request.Name));

            return (List<CountryView>)await result.ToListAsync(cancellationToken);
        }

    }
}
