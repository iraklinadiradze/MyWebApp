using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Product;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Product.ProductCategory.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommand : IRequest<DataAccessLayer.Model.Product.ProductCategory>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.ProductCategory productCategory { get; set; }
    }

    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, DataAccessLayer.Model.Product.ProductCategory>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductCategoryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductCategory> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = request.productCategory;

            _context.ProductCategory.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
