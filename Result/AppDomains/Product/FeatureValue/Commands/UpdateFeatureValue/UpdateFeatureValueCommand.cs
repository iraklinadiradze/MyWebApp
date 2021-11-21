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

namespace Application.Domains.Product.FeatureValue.Commands.UpdateFeatureValue
{
    public class UpdateFeatureValueCommand : IRequest<DataAccessLayer.Model.Product.FeatureValue>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.FeatureValue FeatureValue { get; set; }
    }

    public class UpdateFeatureValueCommandHandler : IRequestHandler<UpdateFeatureValueCommand, DataAccessLayer.Model.Product.FeatureValue>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateFeatureValueCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.FeatureValue> Handle(UpdateFeatureValueCommand request, CancellationToken cancellationToken)
        {

            var entity = request.FeatureValue;

            var _entity = await _context.FeatureValue.FindAsync(request.FeatureValue.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(FeatureValue), entity.Id);
            }

            _context.FeatureValue.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
