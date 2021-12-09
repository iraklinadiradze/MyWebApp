using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.GeneralLedger;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.GeneralLedger.FinAccount.Commands.UpdateFinAccount
{
    public class UpdateFinAccountCommand : IRequest<Application.Model.GeneralLedger.FinAccount>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.GeneralLedger.FinAccount FinAccount { get; set; }
    }

    public class UpdateFinAccountCommandHandler : IRequestHandler<UpdateFinAccountCommand, Application.Model.GeneralLedger.FinAccount>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateFinAccountCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.GeneralLedger.FinAccount> Handle(UpdateFinAccountCommand request, CancellationToken cancellationToken)
        {

            var entity = request.FinAccount;

            var _entity = await _context.FinAccount.FindAsync(request.FinAccount.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(FinAccount), entity.Id);
            }

            _context.FinAccount.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
