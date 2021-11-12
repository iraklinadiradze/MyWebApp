using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.GeneralLedger;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;

namespace Application.Domains.GeneralLedger.GlAccount.Commands.UpdateGlAccount
{
    public class UpdateGlAccountCommand : IRequest<DataAccessLayer.Model.GeneralLedger.GlAccount>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.GeneralLedger.GlAccount glAccount { get; set; }
    }

    public class UpdateGlAccountCommandHandler : IRequestHandler<UpdateGlAccountCommand, DataAccessLayer.Model.GeneralLedger.GlAccount>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateGlAccountCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.GeneralLedger.GlAccount> Handle(UpdateGlAccountCommand request, CancellationToken cancellationToken)
        {

            var entity = request.glAccount;

            var _entity = await _context.GlAccount.FindAsync(request.glAccount.Id);

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
