using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Procurment;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Procurment.PurchaseDetail.Queries.GetPurchaseDetail
{

    public class GetPurchaseDetailQuery : IRequest<DataAccessLayer.Model.Procurment.PurchaseDetail>
    {
        public int? Id { get; set; }
    }

    public class GetPurchaseDetailQueryHandler : IRequestHandler<GetPurchaseDetailQuery, DataAccessLayer.Model.Procurment.PurchaseDetail>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseDetailQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Procurment.PurchaseDetail> Handle(GetPurchaseDetailQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.PurchaseDetail
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PurchaseDetail), request.Id);
            }

            return entity;

        }

    }
}
