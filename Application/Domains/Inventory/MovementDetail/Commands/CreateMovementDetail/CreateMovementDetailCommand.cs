using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Inventory;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Inventory.MovementDetail.Commands.CreateMovementDetail
{
    public class CreateMovementDetailCommand : IRequest<DataAccessLayer.Model.Inventory.MovementDetail>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Inventory.MovementDetail movementDetail { get; set; }
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
            var entity = request.movementDetail;

            _context.MovementDetail.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
