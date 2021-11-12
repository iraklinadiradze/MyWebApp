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

namespace Application.Domains.Sale.SaleProduct.Commands.UpdateSaleProduct
{
    public class UpdateSaleProductCommand : IRequest<DataAccessLayer.Model.Sale.SaleProduct>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Sale.SaleProduct saleProduct { get; set; }
    }

    public class UpdateSaleProductCommandHandler : IRequestHandler<UpdateSaleProductCommand, DataAccessLayer.Model.Sale.SaleProduct>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateSaleProductCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.SaleProduct> Handle(UpdateSaleProductCommand request, CancellationToken cancellationToken)
        {

            var entity = request.saleProduct;

            var _entity = await _context.SaleProduct.FindAsync(request.saleProduct.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(SaleProduct), entity.Id);
            }

            _context.SaleProduct.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
