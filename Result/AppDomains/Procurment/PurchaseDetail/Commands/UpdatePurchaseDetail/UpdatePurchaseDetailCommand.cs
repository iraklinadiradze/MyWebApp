using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Procurment;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;

namespace Application.Domains.Procurment.PurchaseDetail.Commands.UpdatePurchaseDetail
{
    public class UpdatePurchaseDetailCommand : IRequest<DataAccessLayer.Model.Procurment.PurchaseDetail>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Procurment.PurchaseDetail purchaseDetail { get; set; }
    }

    public class UpdatePurchaseDetailCommandHandler : IRequestHandler<UpdatePurchaseDetailCommand, DataAccessLayer.Model.Procurment.PurchaseDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Procurment.PurchaseDetail> Handle(UpdatePurchaseDetailCommand request, CancellationToken cancellationToken)
        {

            var entity = request.purchaseDetail;

            var _entity = await _context.PurchaseDetail.FindAsync(request.purchaseDetail.Id);

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
