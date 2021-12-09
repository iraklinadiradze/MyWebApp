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

namespace Application.Domains.Procurment.PurchaseDetail.Commands.CreatePurchaseDetail
{
    public class CreatePurchaseDetailCommand : IRequest<Application.Model.Procurment.PurchaseDetail>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Procurment.PurchaseDetail PurchaseDetail { get; set; }
    }

    public class CreatePurchaseDetailCommandHandler : IRequestHandler<CreatePurchaseDetailCommand, Application.Model.Procurment.PurchaseDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePurchaseDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Procurment.PurchaseDetail> Handle(CreatePurchaseDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = request.PurchaseDetail;

            _context.PurchaseDetail.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
