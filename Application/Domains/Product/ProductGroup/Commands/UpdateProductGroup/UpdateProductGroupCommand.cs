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

namespace Application.Domains.Product.ProductGroup.Commands.UpdateProductGroup
{
    public class UpdateProductGroupCommand : IRequest<DataAccessLayer.Model.Product.ProductGroup>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.ProductGroup productGroup { get; set; }
    }

    public class UpdateProductGroupCommandHandler : IRequestHandler<UpdateProductGroupCommand, DataAccessLayer.Model.Product.ProductGroup>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductGroupCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductGroup> Handle(UpdateProductGroupCommand request, CancellationToken cancellationToken)
        {

            var entity = request.productGroup;

            var _entity = await _context.ProductGroup.FindAsync(request.productGroup.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductGroup), entity.Id);
            }

            _context.ProductGroup.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
