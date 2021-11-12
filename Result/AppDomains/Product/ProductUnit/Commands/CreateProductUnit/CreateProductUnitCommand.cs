using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Product;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Product.ProductUnit.Commands.CreateProductUnit
{
    public class CreateProductUnitCommand : IRequest<DataAccessLayer.Model.Product.ProductUnit>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.ProductUnit productUnit { get; set; }
    }

    public class CreateProductUnitCommandHandler : IRequestHandler<CreateProductUnitCommand, DataAccessLayer.Model.Product.ProductUnit>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductUnitCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductUnit> Handle(CreateProductUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = request.productUnit;

            _context.ProductUnit.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
