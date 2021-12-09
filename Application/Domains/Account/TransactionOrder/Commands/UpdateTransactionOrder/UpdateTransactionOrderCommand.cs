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

namespace Application.Domains.Account.TransactionOrder.Commands.UpdateTransactionOrder
{
    public class UpdateTransactionOrderCommand : IRequest<Application.Model.Account.TransactionOrder>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Account.TransactionOrder TransactionOrder { get; set; }
    }

    public class UpdateTransactionOrderCommandHandler : IRequestHandler<UpdateTransactionOrderCommand, Application.Model.Account.TransactionOrder>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateTransactionOrderCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Account.TransactionOrder> Handle(UpdateTransactionOrderCommand request, CancellationToken cancellationToken)
        {

            var entity = request.TransactionOrder;

            var _entity = await _context.TransactionOrder.FindAsync(request.TransactionOrder.Id);

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
