using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Procurment;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Procurment.Purchase.Commands.CreatePurchase
{
    public class CreatePurchaseCommand : IRequest<DataAccessLayer.Model.Procurment.Purchase>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Procurment.Purchase Purchase { get; set; }
    }

    public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, DataAccessLayer.Model.Procurment.Purchase>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePurchaseCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Procurment.Purchase> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Purchase;

            _context.Purchase.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
