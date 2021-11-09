using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Client;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Client.Client.Queries.GetClientList
{

    public class GetClientListQuery : IRequest<ClientView>
    {
        public int? id { get; set; }
        public int? topRecords { get; set; }
        public string? name { get; set; }
//        public string? firstName { get; set; }
//        public string? lastName { get; set; }
//        public string? pid { get; set; }
//        public DateTime? bodFrom { get; set; }
//        public DateTime? bodTo { get; set; }
//        public int? clientTypeID { get; set; }
    }

    public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, ClientView>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetClientListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<ClientView> Handle(GetClientListQuery request, CancellationToken cancellationToken)
        {

            var result = from a in _context.Client select a;
                
            if (request.id != null)
                result = result.Where(r => r.Id == request.id);

            if (request.topRecords != null)
                result = result.Take((int)request.topRecords);

            if (request.firstName != null)
                result = result.Where(r => r.Name.StartsWith(request.name));

//            if (request.lastName != null)
//                result = result.Where(r => r.Name.StartsWith(request.lastName));

//            if (request.pid != null)
//                result = result.Where(r => r.client.PersonalId == request.pid);

//            if (request.bodFrom != null)
//                result = result.Where(r => r.client.BirthDate >= (DateTime)request.bodFrom);

//            if (request.bodTo != null)
//                result = result.Where(r => r.client.BirthDate >= (DateTime)request.bodTo);

            return (ClientView)await result.ToListAsync(cancellationToken);
        }

    }
}
