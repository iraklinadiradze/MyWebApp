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

namespace Application.Domains.Product.ProductGroup.Commands.CreateProductGroup
{
    public class CreateProductGroupCommand : IRequest<Application.Model.Product.ProductGroup>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.ProductGroup ProductGroup { get; set; }
    }

    public class CreateProductGroupCommandHandler : IRequestHandler<CreateProductGroupCommand, Application.Model.Product.ProductGroup>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductGroupCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.ProductGroup> Handle(CreateProductGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = request.ProductGroup;

            _context.ProductGroup.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
