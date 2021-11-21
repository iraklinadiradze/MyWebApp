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

namespace Application.Domains.Product.ProductProcessorSalePrice.Commands.DeleteProductProcessorSalePrice
{
    public class DeleteProductProcessorSalePriceCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteProductProcessorSalePriceCommandHandler : IRequestHandler<DeleteProductProcessorSalePriceCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteProductProcessorSalePriceCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteProductProcessorSalePriceCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.ProductProcessorSalePrice.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductProcessorSalePrice), request.Id);
            }

            _context.ProductProcessorSalePrice.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
