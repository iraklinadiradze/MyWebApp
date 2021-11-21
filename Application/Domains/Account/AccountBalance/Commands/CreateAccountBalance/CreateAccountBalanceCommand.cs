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

namespace Application.Domains.Account.AccountBalance.Commands.CreateAccountBalance
{
    public class CreateAccountBalanceCommand : IRequest<DataAccessLayer.Model.Account.AccountBalance>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Account.AccountBalance AccountBalance { get; set; }
    }

    public class CreateAccountBalanceCommandHandler : IRequestHandler<CreateAccountBalanceCommand, DataAccessLayer.Model.Account.AccountBalance>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateAccountBalanceCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Account.AccountBalance> Handle(CreateAccountBalanceCommand request, CancellationToken cancellationToken)
        {
            var entity = request.AccountBalance;

            _context.AccountBalance.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
