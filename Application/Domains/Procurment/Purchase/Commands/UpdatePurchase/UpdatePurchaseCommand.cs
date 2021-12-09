using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.Procurment;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Procurment.Purchase.Commands.UpdatePurchase
{
    public class UpdatePurchaseCommand : IRequest<Application.Model.Procurment.Purchase>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Procurment.Purchase Purchase { get; set; }
    }

    public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand, Application.Model.Procurment.Purchase>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Procurment.Purchase> Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Purchase;

            var _entity = await _context.Purchase.FindAsync(request.Purchase.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Purchase), entity.Id);
            }

            _context.Purchase.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
