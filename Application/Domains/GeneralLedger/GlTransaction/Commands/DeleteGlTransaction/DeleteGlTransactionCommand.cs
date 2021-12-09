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

namespace Application.Domains.GeneralLedger.GlTransaction.Commands.DeleteGlTransaction
{
    public class DeleteGlTransactionCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteGlTransactionCommandHandler : IRequestHandler<DeleteGlTransactionCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteGlTransactionCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteGlTransactionCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.GlTransaction.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(GlTransaction), request.Id);
            }

            _context.GlTransaction.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
