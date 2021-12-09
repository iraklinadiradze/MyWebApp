using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Account;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Account.Transaction.Commands.CreateTransaction
{
    public class CreateTransactionCommand : IRequest<Application.Model.Account.Transaction>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Account.Transaction Transaction { get; set; }
    }

    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Application.Model.Account.Transaction>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateTransactionCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Account.Transaction> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Transaction;

            _context.Transaction.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
