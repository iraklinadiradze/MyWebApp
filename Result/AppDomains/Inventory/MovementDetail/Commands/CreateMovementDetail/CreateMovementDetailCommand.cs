using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Inventory;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Inventory.MovementDetail.Commands.CreateMovementDetail
{
    public class CreateMovementDetailCommand : IRequest<DataAccessLayer.Model.Inventory.MovementDetail>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Inventory.MovementDetail MovementDetail { get; set; }
    }

    public class CreateMovementDetailCommandHandler : IRequestHandler<CreateMovementDetailCommand, DataAccessLayer.Model.Inventory.MovementDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateMovementDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Inventory.MovementDetail> Handle(CreateMovementDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = request.MovementDetail;

            _context.MovementDetail.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
