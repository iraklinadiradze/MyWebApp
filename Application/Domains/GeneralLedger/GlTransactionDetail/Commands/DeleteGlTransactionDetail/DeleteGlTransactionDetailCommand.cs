using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.GeneralLedger;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.GeneralLedger.GlTransactionDetail.Commands.DeleteGlTransactionDetail
{
    public class DeleteGlTransactionDetailCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteGlTransactionDetailCommandHandler : IRequestHandler<DeleteGlTransactionDetailCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteGlTransactionDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteGlTransactionDetailCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.GlTransactionDetail.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(GlTransactionDetail), request.Id);
            }

            _context.GlTransactionDetail.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
