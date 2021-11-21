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

namespace Application.Domains.Procurment.PurchaseDetailPostType.Commands.CreatePurchaseDetailPostType
{
    public class CreatePurchaseDetailPostTypeCommand : IRequest<DataAccessLayer.Model.Procurment.PurchaseDetailPostType>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Procurment.PurchaseDetailPostType PurchaseDetailPostType { get; set; }
    }

    public class CreatePurchaseDetailPostTypeCommandHandler : IRequestHandler<CreatePurchaseDetailPostTypeCommand, DataAccessLayer.Model.Procurment.PurchaseDetailPostType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePurchaseDetailPostTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Procurment.PurchaseDetailPostType> Handle(CreatePurchaseDetailPostTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = request.PurchaseDetailPostType;

            _context.PurchaseDetailPostType.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
