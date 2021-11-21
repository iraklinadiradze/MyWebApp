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
using Application.Common;

namespace Application.Domains.Product.ProductProcessor.Commands.DeleteProductProcessor
{
    public class DeleteProductProcessorCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteProductProcessorCommandHandler : IRequestHandler<DeleteProductProcessorCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteProductProcessorCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteProductProcessorCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.ProductProcessor.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductProcessor), request.Id);
            }

            _context.ProductProcessor.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
