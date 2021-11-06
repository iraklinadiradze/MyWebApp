using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Product;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;

namespace Application.Domains.Product.ProductProcessorDetail.Commands.UpdateProductProcessorDetail
{
    public class UpdateProductProcessorDetailCommand : IRequest<DataAccessLayer.Model.Product.ProductProcessorDetail>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.ProductProcessorDetail productProcessorDetail { get; set; }
    }

    public class UpdateProductProcessorDetailCommandHandler : IRequestHandler<UpdateProductProcessorDetailCommand, DataAccessLayer.Model.Product.ProductProcessorDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductProcessorDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductProcessorDetail> Handle(UpdateProductProcessorDetailCommand request, CancellationToken cancellationToken)
        {

            var entity = request.productProcessorDetail;

            var _entity = await _context.ProductProcessorDetail.FindAsync(request.productProcessorDetail.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductProcessorDetail), entity.Id);
            }

            _context.ProductProcessorDetail.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
