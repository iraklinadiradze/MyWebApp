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

namespace Application.Domains.Product.ProductProcessorDetail.Commands.DeleteProductProcessorDetail
{
    public class DeleteProductProcessorDetailCommand : IRequest<int>
    {
        public int senderId { get; set; }  = 0;
        public int Id { get; set; }
    }

    public class DeleteProductProcessorDetailCommandHandler : IRequestHandler<DeleteProductProcessorDetailCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteProductProcessorDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteProductProcessorDetailCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.ProductProcessorDetail.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductProcessorDetail), request.Id);
            }

            _context.ProductProcessorDetail.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
