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

namespace Application.Domains.Product.ProductUnit.Commands.DeleteProductUnit
{
    public class DeleteProductUnitCommand : IRequest<int>
    {
        public int senderId { get; set; }  = 0;
        public int Id { get; set; }
    }

    public class DeleteProductUnitCommandHandler : IRequestHandler<DeleteProductUnitCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteProductUnitCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteProductUnitCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.ProductUnit.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductUnit), request.Id);
            }

            _context.ProductUnit.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
