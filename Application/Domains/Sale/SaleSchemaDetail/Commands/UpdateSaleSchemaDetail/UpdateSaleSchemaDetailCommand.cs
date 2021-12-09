using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.Sale;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Sale.SaleSchemaDetail.Commands.UpdateSaleSchemaDetail
{
    public class UpdateSaleSchemaDetailCommand : IRequest<Application.Model.Sale.SaleSchemaDetail>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Sale.SaleSchemaDetail SaleSchemaDetail { get; set; }
    }

    public class UpdateSaleSchemaDetailCommandHandler : IRequestHandler<UpdateSaleSchemaDetailCommand, Application.Model.Sale.SaleSchemaDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateSaleSchemaDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Sale.SaleSchemaDetail> Handle(UpdateSaleSchemaDetailCommand request, CancellationToken cancellationToken)
        {

            var entity = request.SaleSchemaDetail;

            var _entity = await _context.SaleSchemaDetail.FindAsync(request.SaleSchemaDetail.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(SaleSchemaDetail), entity.Id);
            }

            _context.SaleSchemaDetail.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
