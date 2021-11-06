using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Product;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Product.Feature.Commands.CreateFeature
{
    public class CreateFeatureCommand : IRequest<DataAccessLayer.Model.Product.Feature>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.Feature feature { get; set; }
    }

    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand, DataAccessLayer.Model.Product.Feature>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateFeatureCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.Feature> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = request.feature;

            _context.Feature.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
