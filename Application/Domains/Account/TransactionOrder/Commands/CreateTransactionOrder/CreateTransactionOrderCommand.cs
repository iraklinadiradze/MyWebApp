using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Account;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Account.TransactionOrder.Commands.CreateTransactionOrder
{
    public class CreateTransactionOrderCommand : IRequest<DataAccessLayer.Model.Account.TransactionOrder>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Account.TransactionOrder transactionOrder { get; set; }
    }

    public class CreateTransactionOrderCommandHandler : IRequestHandler<CreateTransactionOrderCommand, DataAccessLayer.Model.Account.TransactionOrder>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateTransactionOrderCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Account.TransactionOrder> Handle(CreateTransactionOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = request.transactionOrder;

            _context.TransactionOrder.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
