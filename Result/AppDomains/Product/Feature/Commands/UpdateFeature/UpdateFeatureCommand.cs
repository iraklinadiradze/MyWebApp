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

namespace Application.Domains.Product.Feature.Commands.UpdateFeature
{
    public class UpdateFeatureCommand : IRequest<DataAccessLayer.Model.Product.Feature>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.Feature feature { get; set; }
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

            var entity = request.feature;

            var _entity = await _context.Feature.FindAsync(request.feature.Id);

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
