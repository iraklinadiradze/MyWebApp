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
using Application.Domains.Procurment.PurchaseDetail.Commands.UpdatePurchaseSummary;

namespace Application.Domains.Procurment.PurchaseDetail.Commands.DeletePurchaseDetail
{
    public class DeletePurchaseDetailCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeletePurchaseDetailCommandHandler : IRequestHandler<DeletePurchaseDetailCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeletePurchaseDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeletePurchaseDetailCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.PurchaseDetail.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(PurchaseDetail), request.Id);
            }

            _context.PurchaseDetail.Remove(_entity);

            _ = await _mediator.Send(
                new UpdatePurchaseSummaryCommand
                {
                    PurchaseDetail = _entity,
                    isIncrease = false
                }
            );


            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
