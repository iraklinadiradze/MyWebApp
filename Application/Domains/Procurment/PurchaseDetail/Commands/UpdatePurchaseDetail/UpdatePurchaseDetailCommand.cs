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

namespace Application.Domains.Procurment.PurchaseDetail.Commands.UpdatePurchaseDetail
{
    public class UpdatePurchaseDetailCommand : IRequest<Application.Model.Procurment.PurchaseDetail>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Procurment.PurchaseDetail PurchaseDetail { get; set; }
    }

    public class UpdatePurchaseDetailCommandHandler : IRequestHandler<UpdatePurchaseDetailCommand, Application.Model.Procurment.PurchaseDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Procurment.PurchaseDetail> Handle(UpdatePurchaseDetailCommand request, CancellationToken cancellationToken)
        {

            var entity = request.PurchaseDetail;

            var _entity = await _context.PurchaseDetail.FindAsync(request.PurchaseDetail.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(PurchaseDetail), entity.Id);
            }

            _context.PurchaseDetail.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
