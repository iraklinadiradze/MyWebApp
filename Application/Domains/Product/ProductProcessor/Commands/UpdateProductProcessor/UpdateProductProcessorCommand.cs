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

namespace Application.Domains.Product.ProductProcessor.Commands.UpdateProductProcessor
{
    public class UpdateProductProcessorCommand : IRequest<Application.Model.Product.ProductProcessor>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.ProductProcessor ProductProcessor { get; set; }
    }

    public class UpdateProductProcessorCommandHandler : IRequestHandler<UpdateProductProcessorCommand, Application.Model.Product.ProductProcessor>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductProcessorCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.ProductProcessor> Handle(UpdateProductProcessorCommand request, CancellationToken cancellationToken)
        {

            var entity = request.ProductProcessor;

            var _entity = await _context.ProductProcessor.FindAsync(request.ProductProcessor.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductProcessor), entity.Id);
            }

            _context.ProductProcessor.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
