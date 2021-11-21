using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.GeneralLedger;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.GeneralLedger.FinAccount.Commands.CreateFinAccount
{
    public class CreateFinAccountCommand : IRequest<DataAccessLayer.Model.GeneralLedger.FinAccount>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.GeneralLedger.FinAccount FinAccount { get; set; }
    }

    public class CreateFinAccountCommandHandler : IRequestHandler<CreateFinAccountCommand, DataAccessLayer.Model.GeneralLedger.FinAccount>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateFinAccountCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.GeneralLedger.FinAccount> Handle(CreateFinAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = request.FinAccount;

            _context.FinAccount.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
