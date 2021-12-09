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

namespace Application.Domains.Product.ProductGroupTemplate.Commands.UpdateProductGroupTemplate
{
    public class UpdateProductGroupTemplateCommand : IRequest<Application.Model.Product.ProductGroupTemplate>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.ProductGroupTemplate ProductGroupTemplate { get; set; }
    }

    public class UpdateProductGroupTemplateCommandHandler : IRequestHandler<UpdateProductGroupTemplateCommand, Application.Model.Product.ProductGroupTemplate>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductGroupTemplateCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.ProductGroupTemplate> Handle(UpdateProductGroupTemplateCommand request, CancellationToken cancellationToken)
        {

            var entity = request.ProductGroupTemplate;

            var _entity = await _context.ProductGroupTemplate.FindAsync(request.ProductGroupTemplate.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductGroupTemplate), entity.Id);
            }

            _context.ProductGroupTemplate.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
