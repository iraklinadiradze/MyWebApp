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

namespace Application.Domains.Product.ProductLabel.Commands.UpdateProductLabel
{
    public class UpdateProductLabelCommand : IRequest<DataAccessLayer.Model.Product.ProductLabel>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.ProductLabel ProductLabel { get; set; }
    }

    public class UpdateProductLabelCommandHandler : IRequestHandler<UpdateProductLabelCommand, DataAccessLayer.Model.Product.ProductLabel>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductLabelCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductLabel> Handle(UpdateProductLabelCommand request, CancellationToken cancellationToken)
        {

            var entity = request.ProductLabel;

            var _entity = await _context.ProductLabel.FindAsync(request.ProductLabel.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductLabel), entity.Id);
            }

            _context.ProductLabel.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
