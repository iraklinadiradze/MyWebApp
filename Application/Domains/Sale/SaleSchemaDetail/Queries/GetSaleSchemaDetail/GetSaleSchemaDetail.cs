using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Sale;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Sale.SaleSchemaDetail.Queries.GetSaleSchemaDetail
{

    public class GetSaleSchemaDetailQuery : IRequest<Application.Model.Sale.SaleSchemaDetail>
    {
        public int? Id { get; set; }
    }

    public class GetSaleSchemaDetailQueryHandler : IRequestHandler<GetSaleSchemaDetailQuery, Application.Model.Sale.SaleSchemaDetail>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetSaleSchemaDetailQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Sale.SaleSchemaDetail> Handle(GetSaleSchemaDetailQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.SaleSchemaDetail
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SaleSchemaDetail), request.Id);
            }

            return entity;

        }

    }
}
