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

namespace Application.Domains.Account.AccountBalance.Commands.UpdateAccountBalance
{
    public class UpdateAccountBalanceCommand : IRequest<Application.Model.Account.AccountBalance>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Account.AccountBalance AccountBalance { get; set; }
    }

    public class UpdateAccountBalanceCommandHandler : IRequestHandler<UpdateAccountBalanceCommand, Application.Model.Account.AccountBalance>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateAccountBalanceCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Account.AccountBalance> Handle(UpdateAccountBalanceCommand request, CancellationToken cancellationToken)
        {

            var entity = request.AccountBalance;

            var _entity = await _context.AccountBalance.FindAsync(request.AccountBalance.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(AccountBalance), entity.Id);
            }

            _context.AccountBalance.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
