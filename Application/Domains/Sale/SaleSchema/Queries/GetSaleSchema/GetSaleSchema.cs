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

namespace Application.Domains.Sale.SaleSchema.Queries.GetSaleSchema
{

    public class GetSaleSchemaQuery : IRequest<Application.Model.Sale.SaleSchema>
    {
        public int? Id { get; set; }
    }

    public class GetSaleSchemaQueryHandler : IRequestHandler<GetSaleSchemaQuery, Application.Model.Sale.SaleSchema>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetSaleSchemaQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Sale.SaleSchema> Handle(GetSaleSchemaQuery request, CancellationToken cancellationToken)
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
