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

namespace Application.Domains.Product.Feature.Commands.CreateFeature
{
    public class CreateFeatureCommand : IRequest<Application.Model.Product.Feature>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.Feature Feature { get; set; }
    }

    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand, Application.Model.Product.Feature>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateFeatureCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.Feature> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Feature;

            _context.Feature.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
