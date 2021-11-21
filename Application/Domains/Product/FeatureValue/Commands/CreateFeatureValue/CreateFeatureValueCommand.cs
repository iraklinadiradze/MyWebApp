using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Product;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Product.FeatureValue.Commands.CreateFeatureValue
{
    public class CreateFeatureValueCommand : IRequest<DataAccessLayer.Model.Product.FeatureValue>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.FeatureValue FeatureValue { get; set; }
    }

    public class CreateFeatureValueCommandHandler : IRequestHandler<CreateFeatureValueCommand, DataAccessLayer.Model.Product.FeatureValue>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateFeatureValueCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.FeatureValue> Handle(CreateFeatureValueCommand request, CancellationToken cancellationToken)
        {
            var entity = request.FeatureValue;

            _context.FeatureValue.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
