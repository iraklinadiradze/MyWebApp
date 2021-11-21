using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Account;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Account.Transaction.Commands.CreateTransaction
{
    public class CreateTransactionCommand : IRequest<DataAccessLayer.Model.Account.Transaction>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Account.Transaction Transaction { get; set; }
    }

    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, DataAccessLayer.Model.Account.Transaction>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateTransactionCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Account.Transaction> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Transaction;

            _context.Transaction.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
