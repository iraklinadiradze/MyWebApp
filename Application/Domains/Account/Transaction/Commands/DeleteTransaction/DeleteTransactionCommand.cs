using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Account;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;

namespace Application.Domains.Account.Transaction.Commands.DeleteTransaction
{
    public class DeleteTransactionCommand : IRequest<int>
    {
        public int senderId { get; set; }  = 0;
        public int Id { get; set; }
    }

    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteTransactionCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.Transaction.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Transaction), request.Id);
            }

            _context.Transaction.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
