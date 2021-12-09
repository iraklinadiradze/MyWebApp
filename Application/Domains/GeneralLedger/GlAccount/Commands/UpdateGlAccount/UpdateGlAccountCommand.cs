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

namespace Application.Domains.GeneralLedger.GlAccount.Commands.UpdateGlAccount
{
    public class UpdateGlAccountCommand : IRequest<Application.Model.GeneralLedger.GlAccount>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.GeneralLedger.GlAccount GlAccount { get; set; }
    }

    public class UpdateGlAccountCommandHandler : IRequestHandler<UpdateGlAccountCommand, Application.Model.GeneralLedger.GlAccount>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateGlAccountCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.GeneralLedger.GlAccount> Handle(UpdateGlAccountCommand request, CancellationToken cancellationToken)
        {

            var entity = request.GlAccount;

            var _entity = await _context.GlAccount.FindAsync(request.GlAccount.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(GlAccount), entity.Id);
            }

            _context.GlAccount.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
