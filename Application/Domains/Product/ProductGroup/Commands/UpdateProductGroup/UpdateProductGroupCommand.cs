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

namespace Application.Domains.Product.ProductGroup.Commands.UpdateProductGroup
{
    public class UpdateProductGroupCommand : IRequest<Application.Model.Product.ProductGroup>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.ProductGroup ProductGroup { get; set; }
    }

    public class UpdateProductGroupCommandHandler : IRequestHandler<UpdateProductGroupCommand, Application.Model.Product.ProductGroup>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductGroupCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.ProductGroup> Handle(UpdateProductGroupCommand request, CancellationToken cancellationToken)
        {

            var entity = request.ProductGroup;

            var _entity = await _context.ProductGroup.FindAsync(request.ProductGroup.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductGroup), entity.Id);
            }

            _context.ProductGroup.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
