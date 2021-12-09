using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Procurment;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Procurment.PurchaseDetailPostType.Queries.GetPurchaseDetailPostType
{

    public class GetPurchaseDetailPostTypeQuery : IRequest<Application.Model.Procurment.PurchaseDetailPostType>
    {
        public int? Id { get; set; }
    }

    public class GetPurchaseDetailPostTypeQueryHandler : IRequestHandler<GetPurchaseDetailPostTypeQuery, Application.Model.Procurment.PurchaseDetailPostType>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseDetailPostTypeQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Procurment.PurchaseDetailPostType> Handle(GetPurchaseDetailPostTypeQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.PurchaseDetailPostType
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PurchaseDetailPostType), request.Id);
            }

            return entity;

        }

    }
}
