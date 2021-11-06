using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Product;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Product.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<DataAccessLayer.Model.Product.Product>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.Product product { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, DataAccessLayer.Model.Product.Product>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = request.product;

            _context.Product.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
