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

namespace Application.Domains.Product.ProductCategory.Commands.DeleteProductCategory
{
    public class DeleteProductCategoryCommand : IRequest<int>
    {
        public int senderId { get; set; }  = 0;
        public int Id { get; set; }
    }

    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteProductCategoryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.ProductCategory.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductCategory), request.Id);
            }

            _context.ProductCategory.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
