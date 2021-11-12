using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.GeneralLedger;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.GeneralLedger.FinAccount.Commands.CreateFinAccount
{
    public class CreateFinAccountCommand : IRequest<DataAccessLayer.Model.GeneralLedger.FinAccount>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.GeneralLedger.FinAccount finAccount { get; set; }
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
            var entity = request.finAccount;

            _context.FinAccount.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
