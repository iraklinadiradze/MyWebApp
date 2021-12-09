using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Procurment;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Procurment.Purchase.Commands.CreatePurchase
{
    public class CreatePurchaseCommand : IRequest<Application.Model.Procurment.Purchase>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Procurment.Purchase Purchase { get; set; }
    }

    public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, Application.Model.Procurment.Purchase>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePurchaseCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Procurment.Purchase> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Purchase;

            _context.Purchase.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
