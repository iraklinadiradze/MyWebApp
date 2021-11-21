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

namespace Application.Domains.Product.Feature.Commands.UpdateFeature
{
    public class UpdateFeatureCommand : IRequest<DataAccessLayer.Model.Product.Feature>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.Feature Feature { get; set; }
    }

    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand, DataAccessLayer.Model.Product.Feature>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateFeatureCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.Feature> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Feature;

            var _entity = await _context.Feature.FindAsync(request.Feature.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Feature), entity.Id);
            }

            _context.Feature.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
