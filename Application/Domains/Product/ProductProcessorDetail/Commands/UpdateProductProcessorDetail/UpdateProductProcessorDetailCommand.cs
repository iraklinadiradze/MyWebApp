using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.Product;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Product.ProductProcessorDetail.Commands.UpdateProductProcessorDetail
{
    public class UpdateProductProcessorDetailCommand : IRequest<Application.Model.Product.ProductProcessorDetail>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.ProductProcessorDetail ProductProcessorDetail { get; set; }
    }

    public class UpdateProductProcessorDetailCommandHandler : IRequestHandler<UpdateProductProcessorDetailCommand, Application.Model.Product.ProductProcessorDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductProcessorDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.ProductProcessorDetail> Handle(UpdateProductProcessorDetailCommand request, CancellationToken cancellationToken)
        {

            var entity = request.ProductProcessorDetail;

            var _entity = await _context.ProductProcessorDetail.FindAsync(request.ProductProcessorDetail.Id);

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
