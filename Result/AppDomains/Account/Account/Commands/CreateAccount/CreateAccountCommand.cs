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

namespace Application.Domains.Account.Account.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<DataAccessLayer.Model.Account.Account>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Account.Account Account { get; set; }
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, DataAccessLayer.Model.Account.Account>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateAccountCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Account.Account> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Account;

            _context.Account.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
