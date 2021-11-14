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

namespace Application.Domains.Sale.ReturnProduct.Queries.GetReturnProduct
{

    public class GetReturnProductQuery : IRequest<DataAccessLayer.Model.Sale.ReturnProduct>
    {
        public int? Id { get; set; }
    }

    public class GetReturnProductQueryHandler : IRequestHandler<GetReturnProductQuery, DataAccessLayer.Model.Sale.ReturnProduct>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetReturnProductQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Sale.ReturnProduct> Handle(GetReturnProductQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.ReturnProduct
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ReturnProduct), request.Id);
            }

            return entity;

        }

    }
}
