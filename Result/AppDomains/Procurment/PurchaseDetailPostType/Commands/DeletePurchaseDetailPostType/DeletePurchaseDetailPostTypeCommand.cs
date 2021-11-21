using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Procurment;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Procurment.PurchaseDetailPostType.Commands.DeletePurchaseDetailPostType
{
    public class DeletePurchaseDetailPostTypeCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeletePurchaseDetailPostTypeCommandHandler : IRequestHandler<DeletePurchaseDetailPostTypeCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeletePurchaseDetailPostTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeletePurchaseDetailPostTypeCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.PurchaseDetailPostType.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(PurchaseDetailPostType), request.Id);
            }

            _context.PurchaseDetailPostType.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
