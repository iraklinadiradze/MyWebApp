using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.GeneralLedger;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;

namespace Application.Domains.GeneralLedger.FinAccount.Commands.DeleteFinAccount
{
    public class DeleteFinAccountCommand : IRequest<int>
    {
        public int senderId { get; set; }  = 0;
        public int Id { get; set; }
    }

    public class DeleteFinAccountCommandHandler : IRequestHandler<DeleteFinAccountCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteFinAccountCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteFinAccountCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.FinAccount.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(FinAccount), request.Id);
            }

            _context.FinAccount.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
