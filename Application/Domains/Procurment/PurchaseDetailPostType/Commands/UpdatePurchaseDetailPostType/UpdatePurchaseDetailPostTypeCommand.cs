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

namespace Application.Domains.Procurment.PurchaseDetailPostType.Commands.UpdatePurchaseDetailPostType
{
    public class UpdatePurchaseDetailPostTypeCommand : IRequest<Application.Model.Procurment.PurchaseDetailPostType>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Procurment.PurchaseDetailPostType PurchaseDetailPostType { get; set; }
    }

    public class UpdatePurchaseDetailPostTypeCommandHandler : IRequestHandler<UpdatePurchaseDetailPostTypeCommand, Application.Model.Procurment.PurchaseDetailPostType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseDetailPostTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Procurment.PurchaseDetailPostType> Handle(UpdatePurchaseDetailPostTypeCommand request, CancellationToken cancellationToken)
        {

            var entity = request.PurchaseDetailPostType;

            var _entity = await _context.PurchaseDetailPostType.FindAsync(request.PurchaseDetailPostType.Id);

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
