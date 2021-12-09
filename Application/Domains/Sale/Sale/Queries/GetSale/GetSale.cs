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

namespace Application.Domains.Sale.Sale.Queries.GetSale
{

    public class GetSaleQuery : IRequest<Application.Model.Sale.Sale>
    {
        public int? Id { get; set; }
    }

    public class GetSaleQueryHandler : IRequestHandler<GetSaleQuery, Application.Model.Sale.Sale>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetSaleQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Sale.Sale> Handle(GetSaleQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Sale
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Sale), request.Id);
            }

            return entity;

        }

    }
}
