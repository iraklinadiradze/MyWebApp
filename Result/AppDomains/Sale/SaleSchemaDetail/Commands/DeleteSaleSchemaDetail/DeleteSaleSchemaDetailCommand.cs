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

namespace Application.Domains.Sale.SaleSchemaDetail.Commands.DeleteSaleSchemaDetail
{
    public class DeleteSaleSchemaDetailCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteSaleSchemaDetailCommandHandler : IRequestHandler<DeleteSaleSchemaDetailCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteSaleSchemaDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteSaleSchemaDetailCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.SaleSchemaDetail.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(SaleSchemaDetail), request.Id);
            }

            _context.SaleSchemaDetail.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
