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

namespace Application.Domains.Account.Account.Commands.UpdateAccount
{
    public class UpdateAccountCommand : IRequest<DataAccessLayer.Model.Account.Account>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Account.Account account { get; set; }
    }

    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, DataAccessLayer.Model.Account.Account>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateAccountCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Account.Account> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {

            var entity = request.account;

            var _entity = await _context.Account.FindAsync(request.account.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Account), entity.Id);
            }

            _context.Account.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
