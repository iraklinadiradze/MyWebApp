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

namespace Application.Domains.Client.Client.Queries.GetClientList
{

    public class GetClientListQuery : IRequest<int>
    {
        int? id;
        int? topRecords;
        string firstName;
        string lastName;
        string pid;
        DateTime? bodFrom;
        DateTime? bodTo;
        int? clientTypeID;
    }

    class GetClientListQueryHandler: IRequestHandler<GetClientListQuery, ClientView>
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
//            var customers = await _context.Customers
//                .ProjectTo<CustomerLookupDto>(_mapper.ConfigurationProvider)
//                .ToListAsync(cancellationToken);

//            var vm = new CustomersListVm
//            {
//                Customers = customers
//            };

            return 0;
        }

    }
}
