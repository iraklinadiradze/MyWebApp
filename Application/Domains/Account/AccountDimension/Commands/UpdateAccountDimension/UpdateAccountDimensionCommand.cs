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

namespace Application.Domains.Account.AccountDimension.Commands.UpdateAccountDimension
{
    public class UpdateAccountDimensionCommand : IRequest<DataAccessLayer.Model.Account.AccountDimension>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Account.AccountDimension accountDimension { get; set; }
    }

    public class UpdateAccountDimensionCommandHandler : IRequestHandler<UpdateAccountDimensionCommand, DataAccessLayer.Model.Account.AccountDimension>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateAccountDimensionCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Account.AccountDimension> Handle(UpdateAccountDimensionCommand request, CancellationToken cancellationToken)
        {

            var entity = request.accountDimension;

            var _entity = await _context.AccountDimension.FindAsync(request.accountDimension.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(AccountDimension), entity.Id);
            }

            _context.AccountDimension.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
