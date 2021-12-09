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

namespace Application.Domains.Procurment.PurchaseDetailPostType.Commands.CreatePurchaseDetailPostType
{
    public class CreatePurchaseDetailPostTypeCommand : IRequest<Application.Model.Procurment.PurchaseDetailPostType>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Procurment.PurchaseDetailPostType PurchaseDetailPostType { get; set; }
    }

    public class CreatePurchaseDetailPostTypeCommandHandler : IRequestHandler<CreatePurchaseDetailPostTypeCommand, Application.Model.Procurment.PurchaseDetailPostType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePurchaseDetailPostTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Procurment.PurchaseDetailPostType> Handle(CreatePurchaseDetailPostTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = request.PurchaseDetailPostType;

            _context.PurchaseDetailPostType.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
