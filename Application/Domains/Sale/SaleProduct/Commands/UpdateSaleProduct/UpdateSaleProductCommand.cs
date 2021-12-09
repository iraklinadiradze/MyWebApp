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

namespace Application.Domains.Sale.SaleProduct.Commands.UpdateSaleProduct
{
    public class UpdateSaleProductCommand : IRequest<Application.Model.Sale.SaleProduct>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Sale.SaleProduct SaleProduct { get; set; }
    }

    public class UpdateSaleProductCommandHandler : IRequestHandler<UpdateSaleProductCommand, Application.Model.Sale.SaleProduct>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateSaleProductCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Sale.SaleProduct> Handle(UpdateSaleProductCommand request, CancellationToken cancellationToken)
        {

            var entity = request.SaleProduct;

            var _entity = await _context.SaleProduct.FindAsync(request.SaleProduct.Id);

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
