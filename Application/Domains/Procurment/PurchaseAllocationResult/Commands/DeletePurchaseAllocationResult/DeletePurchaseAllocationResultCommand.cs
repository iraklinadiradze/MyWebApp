using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Procurment;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;

namespace Application.Domains.Procurment.PurchaseAllocationResult.Commands.DeletePurchaseAllocationResult
{
    public class DeletePurchaseAllocationResultCommand : IRequest<int>
    {
        public int senderId { get; set; }  = 0;
        public int Id { get; set; }
    }

    public class DeletePurchaseAllocationResultCommandHandler : IRequestHandler<DeletePurchaseAllocationResultCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeletePurchaseAllocationResultCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeletePurchaseAllocationResultCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.PurchaseAllocationResult.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(PurchaseAllocationResult), request.Id);
            }

            _context.PurchaseAllocationResult.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}