using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Product;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Product.ProductProcessorDetail.Queries.GetProductProcessorDetail
{

    public class GetProductProcessorDetailQuery : IRequest<Application.Model.Product.ProductProcessorDetail>
    {
        public int? Id { get; set; }
    }

    public class GetProductProcessorDetailQueryHandler : IRequestHandler<GetProductProcessorDetailQuery, Application.Model.Product.ProductProcessorDetail>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductProcessorDetailQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Product.ProductProcessorDetail> Handle(GetProductProcessorDetailQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.ProductProcessorDetail
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductProcessorDetail), request.Id);
            }

            return entity;

        }

    }
}
