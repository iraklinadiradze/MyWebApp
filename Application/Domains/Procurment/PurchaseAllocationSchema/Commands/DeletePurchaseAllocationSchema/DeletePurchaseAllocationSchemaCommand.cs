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

namespace Application.Domains.Procurment.PurchaseAllocationSchema.Commands.DeletePurchaseAllocationSchema
{
    public class DeletePurchaseAllocationSchemaCommand : IRequest<int>
    {
        public int senderId { get; set; }  = 0;
        public int Id { get; set; }
    }

    public class DeletePurchaseAllocationSchemaCommandHandler : IRequestHandler<DeletePurchaseAllocationSchemaCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeletePurchaseAllocationSchemaCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeletePurchaseAllocationSchemaCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.PurchaseAllocationSchema.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(PurchaseAllocationSchema), request.Id);
            }

            _context.PurchaseAllocationSchema.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
