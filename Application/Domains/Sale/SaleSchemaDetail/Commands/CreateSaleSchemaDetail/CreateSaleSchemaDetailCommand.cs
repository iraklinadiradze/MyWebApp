using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Sale;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Sale.SaleSchemaDetail.Commands.CreateSaleSchemaDetail
{
    public class CreateSaleSchemaDetailCommand : IRequest<Application.Model.Sale.SaleSchemaDetail>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Sale.SaleSchemaDetail SaleSchemaDetail { get; set; }
    }

    public class CreateSaleSchemaDetailCommandHandler : IRequestHandler<CreateSaleSchemaDetailCommand, Application.Model.Sale.SaleSchemaDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateSaleSchemaDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Sale.SaleSchemaDetail> Handle(CreateSaleSchemaDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = request.SaleSchemaDetail;

            _context.SaleSchemaDetail.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
