using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.Inventory;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Inventory.MovementDetail.Commands.DeleteMovementDetail
{
    public class DeleteMovementDetailCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteMovementDetailCommandHandler : IRequestHandler<DeleteMovementDetailCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteMovementDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteMovementDetailCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.MovementDetail.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(MovementDetail), request.Id);
            }

            _context.MovementDetail.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
