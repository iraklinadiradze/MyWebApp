using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Sale;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Sale.SaleSchemaDetail.Commands.CreateSaleSchemaDetail
{
    public class CreateSaleSchemaDetailCommand : IRequest<DataAccessLayer.Model.Sale.SaleSchemaDetail>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Sale.SaleSchemaDetail saleSchemaDetail { get; set; }
    }

    public class CreateSaleSchemaDetailCommandHandler : IRequestHandler<CreateSaleSchemaDetailCommand, DataAccessLayer.Model.Sale.SaleSchemaDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateSaleSchemaDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.SaleSchemaDetail> Handle(CreateSaleSchemaDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = request.saleSchemaDetail;

            _context.SaleSchemaDetail.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
