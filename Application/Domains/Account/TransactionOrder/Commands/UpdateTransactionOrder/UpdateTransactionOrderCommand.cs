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

namespace Application.Domains.Account.TransactionOrder.Commands.UpdateTransactionOrder
{
    public class UpdateTransactionOrderCommand : IRequest<DataAccessLayer.Model.Account.TransactionOrder>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Account.TransactionOrder transactionOrder { get; set; }
    }

    public class UpdateTransactionOrderCommandHandler : IRequestHandler<UpdateTransactionOrderCommand, DataAccessLayer.Model.Account.TransactionOrder>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateTransactionOrderCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Account.TransactionOrder> Handle(UpdateTransactionOrderCommand request, CancellationToken cancellationToken)
        {

            var entity = request.transactionOrder;

            var _entity = await _context.TransactionOrder.FindAsync(request.transactionOrder.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(TransactionOrder), entity.Id);
            }

            _context.TransactionOrder.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
