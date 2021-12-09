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

namespace Application.Domains.Account.AccountDimension.Commands.UpdateAccountDimension
{
    public class UpdateAccountDimensionCommand : IRequest<Application.Model.Account.AccountDimension>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Account.AccountDimension AccountDimension { get; set; }
    }

    public class UpdateAccountDimensionCommandHandler : IRequestHandler<UpdateAccountDimensionCommand, Application.Model.Account.AccountDimension>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateAccountDimensionCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Account.AccountDimension> Handle(UpdateAccountDimensionCommand request, CancellationToken cancellationToken)
        {

            var entity = request.AccountDimension;

            var _entity = await _context.AccountDimension.FindAsync(request.AccountDimension.Id);

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
