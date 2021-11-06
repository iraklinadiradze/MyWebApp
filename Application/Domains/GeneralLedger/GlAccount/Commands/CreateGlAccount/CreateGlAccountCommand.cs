using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.GeneralLedger;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.GeneralLedger.GlAccount.Commands.CreateGlAccount
{
    public class CreateGlAccountCommand : IRequest<DataAccessLayer.Model.GeneralLedger.GlAccount>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.GeneralLedger.GlAccount glAccount { get; set; }
    }

    public class CreateGlAccountCommandHandler : IRequestHandler<CreateGlAccountCommand, DataAccessLayer.Model.GeneralLedger.GlAccount>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateGlAccountCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.GeneralLedger.GlAccount> Handle(CreateGlAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = request.glAccount;

            _context.GlAccount.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
