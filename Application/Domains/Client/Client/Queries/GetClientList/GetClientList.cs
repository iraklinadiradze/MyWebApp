using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Client;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Client.Client.Queries.GetClientList
{

    public class GetClientListQuery : IRequest<List<ClientView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
public String Name {get;set;}
    }

    public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, List<ClientView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetClientListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ClientView>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.Client
                        
                        select new ClientView
                           {
                             Id= e.Id,
IsBank= e.IsBank,
IsCustomer= e.IsCustomer,
IsEmployee= e.IsEmployee,
IsPerson= e.IsPerson,
IsSupplier= e.IsSupplier,
Name= e.Name
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

                if (request.Name!= null) 
 result = result.Where(r => r.Name.StartsWith(request.Name));

            return (List<ClientView>)await result.ToListAsync(cancellationToken);
        }

    }
}
