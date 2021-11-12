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

namespace Application.Domains.Procurment.PurchaseDetailPostType.Commands.UpdatePurchaseDetailPostType
{
    public class UpdatePurchaseDetailPostTypeCommand : IRequest<DataAccessLayer.Model.Procurment.PurchaseDetailPostType>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Procurment.PurchaseDetailPostType purchaseDetailPostType { get; set; }
    }

    public class UpdatePurchaseDetailPostTypeCommandHandler : IRequestHandler<UpdatePurchaseDetailPostTypeCommand, DataAccessLayer.Model.Procurment.PurchaseDetailPostType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseDetailPostTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Procurment.PurchaseDetailPostType> Handle(UpdatePurchaseDetailPostTypeCommand request, CancellationToken cancellationToken)
        {

            var entity = request.purchaseDetailPostType;

            var _entity = await _context.PurchaseDetailPostType.FindAsync(request.purchaseDetailPostType.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(PurchaseDetailPostType), entity.Id);
            }

            _context.PurchaseDetailPostType.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
