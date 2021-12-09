using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.GeneralLedger;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.GeneralLedger.GlAccount.Commands.CreateGlAccount
{
    public class CreateGlAccountCommand : IRequest<Application.Model.GeneralLedger.GlAccount>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.GeneralLedger.GlAccount GlAccount { get; set; }
    }

    public class CreateGlAccountCommandHandler : IRequestHandler<CreateGlAccountCommand, Application.Model.GeneralLedger.GlAccount>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateGlAccountCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.GeneralLedger.GlAccount> Handle(CreateGlAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = request.GlAccount;

            _context.GlAccount.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
