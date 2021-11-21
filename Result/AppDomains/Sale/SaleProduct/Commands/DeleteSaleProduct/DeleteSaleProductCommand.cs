using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Sale;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Sale.SaleProduct.Commands.DeleteSaleProduct
{
    public class DeleteSaleProductCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteSaleProductCommandHandler : IRequestHandler<DeleteSaleProductCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteSaleProductCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteSaleProductCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.SaleProduct.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(SaleProduct), request.Id);
            }

            _context.SaleProduct.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
