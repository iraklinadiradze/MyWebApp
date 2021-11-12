using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Sale;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;

namespace Application.Domains.Sale.SaleSchemaDetail.Commands.UpdateSaleSchemaDetail
{
    public class UpdateSaleSchemaDetailCommand : IRequest<DataAccessLayer.Model.Sale.SaleSchemaDetail>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Sale.SaleSchemaDetail saleSchemaDetail { get; set; }
    }

    public class UpdateSaleSchemaDetailCommandHandler : IRequestHandler<UpdateSaleSchemaDetailCommand, DataAccessLayer.Model.Sale.SaleSchemaDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateSaleSchemaDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.SaleSchemaDetail> Handle(UpdateSaleSchemaDetailCommand request, CancellationToken cancellationToken)
        {

            var entity = request.saleSchemaDetail;

            var _entity = await _context.SaleSchemaDetail.FindAsync(request.saleSchemaDetail.Id);

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
