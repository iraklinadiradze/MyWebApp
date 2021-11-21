using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Inventory;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Inventory.MovementDetail.Commands.UpdateMovementDetail
{
    public class UpdateMovementDetailCommand : IRequest<DataAccessLayer.Model.Inventory.MovementDetail>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Inventory.MovementDetail MovementDetail { get; set; }
    }

    public class UpdateMovementDetailCommandHandler : IRequestHandler<UpdateMovementDetailCommand, DataAccessLayer.Model.Inventory.MovementDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateMovementDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Inventory.MovementDetail> Handle(UpdateMovementDetailCommand request, CancellationToken cancellationToken)
        {

            var entity = request.MovementDetail;

            var _entity = await _context.MovementDetail.FindAsync(request.MovementDetail.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(MovementDetail), entity.Id);
            }

            _context.MovementDetail.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
