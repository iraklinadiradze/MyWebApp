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

namespace Application.Domains.Account.TransactionOrder.Commands.DeleteTransactionOrder
{
    public class DeleteTransactionOrderCommand : IRequest<int>
    {
        public int senderId { get; set; }  = 0;
        public int Id { get; set; }
    }

    public class DeleteTransactionOrderCommandHandler : IRequestHandler<DeleteTransactionOrderCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteTransactionOrderCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteTransactionOrderCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.TransactionOrder.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(TransactionOrder), request.Id);
            }

            _context.TransactionOrder.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
