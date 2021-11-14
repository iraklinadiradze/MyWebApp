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

namespace Application.Domains.Sale.SaleSchema.Queries.GetSaleSchema
{

    public class GetSaleSchemaQuery : IRequest<DataAccessLayer.Model.Sale.SaleSchema>
    {
        public int? Id { get; set; }
    }

    public class GetSaleSchemaQueryHandler : IRequestHandler<GetSaleSchemaQuery, DataAccessLayer.Model.Sale.SaleSchema>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetSaleSchemaQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Sale.SaleSchema> Handle(GetSaleSchemaQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.SaleSchema
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SaleSchema), request.Id);
            }

            return entity;

        }

    }
}
