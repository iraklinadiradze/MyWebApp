using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.Product;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Product.ProductCategory.Commands.UpdateProductCategory
{
    public class UpdateProductCategoryCommand : IRequest<Application.Model.Product.ProductCategory>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.ProductCategory ProductCategory { get; set; }
    }

    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, Application.Model.Product.ProductCategory>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductCategoryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.ProductCategory> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {

            var entity = request.ProductCategory;

            var _entity = await _context.ProductCategory.FindAsync(request.ProductCategory.Id);

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
