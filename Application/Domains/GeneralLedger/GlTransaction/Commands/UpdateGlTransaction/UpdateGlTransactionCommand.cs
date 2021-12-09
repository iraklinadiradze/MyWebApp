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

namespace Application.Domains.GeneralLedger.GlTransaction.Commands.UpdateGlTransaction
{
    public class UpdateGlTransactionCommand : IRequest<Application.Model.GeneralLedger.GlTransaction>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.GeneralLedger.GlTransaction GlTransaction { get; set; }
    }

    public class UpdateGlTransactionCommandHandler : IRequestHandler<UpdateGlTransactionCommand, Application.Model.GeneralLedger.GlTransaction>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateGlTransactionCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.GeneralLedger.GlTransaction> Handle(UpdateGlTransactionCommand request, CancellationToken cancellationToken)
        {

            var entity = request.GlTransaction;

            var _entity = await _context.GlTransaction.FindAsync(request.GlTransaction.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(GlTransaction), entity.Id);
            }

            _context.GlTransaction.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
