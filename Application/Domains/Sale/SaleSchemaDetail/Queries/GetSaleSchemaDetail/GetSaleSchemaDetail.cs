using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Sale;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Sale.SaleSchemaDetail.Queries.GetSaleSchemaDetail
{

    public class GetSaleSchemaDetailQuery : IRequest<DataAccessLayer.Model.Sale.SaleSchemaDetail>
    {
        public int? Id { get; set; }
    }

    public class GetSaleSchemaDetailQueryHandler : IRequestHandler<GetSaleSchemaDetailQuery, DataAccessLayer.Model.Sale.SaleSchemaDetail>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetSaleSchemaDetailQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Sale.SaleSchemaDetail> Handle(GetSaleSchemaDetailQuery request, CancellationToken cancellationToken)
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
