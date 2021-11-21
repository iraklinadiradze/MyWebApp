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
using Application.Common;

namespace Application.Domains.Product.ProductGroupTemplateFeature.Commands.UpdateProductGroupTemplateFeature
{
    public class UpdateProductGroupTemplateFeatureCommand : IRequest<DataAccessLayer.Model.Product.ProductGroupTemplateFeature>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.ProductGroupTemplateFeature ProductGroupTemplateFeature { get; set; }
    }

    public class UpdateProductGroupTemplateFeatureCommandHandler : IRequestHandler<UpdateProductGroupTemplateFeatureCommand, DataAccessLayer.Model.Product.ProductGroupTemplateFeature>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductGroupTemplateFeatureCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductGroupTemplateFeature> Handle(UpdateProductGroupTemplateFeatureCommand request, CancellationToken cancellationToken)
        {

            var entity = request.ProductGroupTemplateFeature;

            var _entity = await _context.ProductGroupTemplateFeature.FindAsync(request.ProductGroupTemplateFeature.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductGroupTemplateFeature), entity.Id);
            }

            _context.ProductGroupTemplateFeature.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
