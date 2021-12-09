using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.Account;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Account.Transaction.Commands.UpdateTransaction
{
    public class UpdateTransactionCommand : IRequest<Application.Model.Account.Transaction>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Account.Transaction Transaction { get; set; }
    }

    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, Application.Model.Account.Transaction>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateTransactionCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Account.Transaction> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Transaction;

            var _entity = await _context.Transaction.FindAsync(request.Transaction.Id);

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
