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

namespace Application.Domains.Product.ProductProcessorProductFeature.Commands.DeleteProductProcessorProductFeature
{
    public class DeleteProductProcessorProductFeatureCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteProductProcessorProductFeatureCommandHandler : IRequestHandler<DeleteProductProcessorProductFeatureCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteProductProcessorProductFeatureCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteProductProcessorProductFeatureCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.ProductProcessorProductFeature.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductProcessorProductFeature), request.Id);
            }

            _context.ProductProcessorProductFeature.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
