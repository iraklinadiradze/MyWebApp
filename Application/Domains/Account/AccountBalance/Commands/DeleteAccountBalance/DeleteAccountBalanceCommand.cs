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

namespace Application.Domains.Account.AccountBalance.Commands.DeleteAccountBalance
{
    public class DeleteAccountBalanceCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteAccountBalanceCommandHandler : IRequestHandler<DeleteAccountBalanceCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteAccountBalanceCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteAccountBalanceCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.AccountBalance.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(AccountBalance), request.Id);
            }

            _context.AccountBalance.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
