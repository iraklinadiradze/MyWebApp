using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Product;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Product.ProductUnit.Commands.UpdateProductUnit
{
    public class UpdateProductUnitCommand : IRequest<DataAccessLayer.Model.Product.ProductUnit>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.ProductUnit ProductUnit { get; set; }
    }

    public class UpdateProductUnitCommandHandler : IRequestHandler<UpdateProductUnitCommand, DataAccessLayer.Model.Product.ProductUnit>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductUnitCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductUnit> Handle(UpdateProductUnitCommand request, CancellationToken cancellationToken)
        {

            var entity = request.ProductUnit;

            var _entity = await _context.ProductUnit.FindAsync(request.ProductUnit.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductUnit), entity.Id);
            }

            _context.ProductUnit.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
