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

namespace Application.Domains.Product.ProductCategory.Commands.UpdateProductCategory
{
    public class UpdateProductCategoryCommand : IRequest<DataAccessLayer.Model.Product.ProductCategory>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.ProductCategory productCategory { get; set; }
    }

    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, DataAccessLayer.Model.Product.ProductCategory>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductCategoryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductCategory> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {

            var entity = request.productCategory;

            var _entity = await _context.ProductCategory.FindAsync(request.productCategory.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductCategory), entity.Id);
            }

            _context.ProductCategory.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
