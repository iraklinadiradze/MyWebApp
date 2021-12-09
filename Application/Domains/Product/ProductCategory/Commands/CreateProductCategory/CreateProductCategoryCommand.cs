using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Product;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Product.ProductCategory.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommand : IRequest<Application.Model.Product.ProductCategory>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.ProductCategory ProductCategory { get; set; }
    }

    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, Application.Model.Product.ProductCategory>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductCategoryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.ProductCategory> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = request.ProductCategory;

            _context.ProductCategory.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
