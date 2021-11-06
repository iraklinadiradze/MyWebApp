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

namespace Application.Domains.Product.ProductGroupTemplateFeature.Commands.DeleteProductGroupTemplateFeature
{
    public class DeleteProductGroupTemplateFeatureCommand : IRequest<int>
    {
        public int senderId { get; set; }  = 0;
        public int Id { get; set; }
    }

    public class DeleteProductGroupTemplateFeatureCommandHandler : IRequestHandler<DeleteProductGroupTemplateFeatureCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteProductGroupTemplateFeatureCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteProductGroupTemplateFeatureCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.ProductGroupTemplateFeature.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductGroupTemplateFeature), request.Id);
            }

            _context.ProductGroupTemplateFeature.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
