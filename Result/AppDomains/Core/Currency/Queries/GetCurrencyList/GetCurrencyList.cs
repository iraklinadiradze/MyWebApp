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

namespace Application.Domains.Core.Currency.Queries.GetCurrencyList
{

    public class GetCurrencyListQuery : IRequest<List<CurrencyView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
public String currencyCode {get;set;}
    }

    public class GetCurrencyListQueryHandler : IRequestHandler<GetCurrencyListQuery, List<CurrencyView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetCurrencyListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<CurrencyView>> Handle(GetCurrencyListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.Currency
                        
                        select new CurrencyView
                           {
                             Id= e.Id,
CurrencyCode= e.CurrencyCode,
CurrencyDescrip= e.CurrencyDescrip
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

                if (request.currencyCode!= null) 
 result = result.Where(r => r.CurrencyCode== request.currencyCode);

            return (List<CurrencyView>)await result.ToListAsync(cancellationToken);
        }

    }
}
