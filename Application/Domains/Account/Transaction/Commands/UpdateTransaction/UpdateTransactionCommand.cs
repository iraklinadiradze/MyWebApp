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

namespace Application.Domains.Account.Transaction.Commands.UpdateTransaction
{
    public class UpdateTransactionCommand : IRequest<DataAccessLayer.Model.Account.Transaction>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Account.Transaction transaction { get; set; }
    }

    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, DataAccessLayer.Model.Account.Transaction>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateTransactionCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Account.Transaction> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {

            var entity = request.transaction;

            var _entity = await _context.Transaction.FindAsync(request.transaction.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Transaction), entity.Id);
            }

            _context.Transaction.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
