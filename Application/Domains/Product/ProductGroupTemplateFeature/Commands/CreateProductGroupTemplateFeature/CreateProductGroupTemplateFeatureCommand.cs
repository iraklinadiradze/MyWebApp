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

namespace Application.Domains.Product.ProductGroupTemplateFeature.Commands.CreateProductGroupTemplateFeature
{
    public class CreateProductGroupTemplateFeatureCommand : IRequest<Application.Model.Product.ProductGroupTemplateFeature>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.ProductGroupTemplateFeature ProductGroupTemplateFeature { get; set; }
    }

    public class CreateProductGroupTemplateFeatureCommandHandler : IRequestHandler<CreateProductGroupTemplateFeatureCommand, Application.Model.Product.ProductGroupTemplateFeature>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductGroupTemplateFeatureCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.ProductGroupTemplateFeature> Handle(CreateProductGroupTemplateFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = request.ProductGroupTemplateFeature;

            _context.ProductGroupTemplateFeature.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
