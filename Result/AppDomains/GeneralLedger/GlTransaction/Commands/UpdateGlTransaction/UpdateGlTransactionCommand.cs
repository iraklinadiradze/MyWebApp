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

namespace Application.Domains.GeneralLedger.GlTransaction.Commands.UpdateGlTransaction
{
    public class UpdateGlTransactionCommand : IRequest<DataAccessLayer.Model.GeneralLedger.GlTransaction>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.GeneralLedger.GlTransaction glTransaction { get; set; }
    }

    public class UpdateGlTransactionCommandHandler : IRequestHandler<UpdateGlTransactionCommand, DataAccessLayer.Model.GeneralLedger.GlTransaction>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateGlTransactionCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.GeneralLedger.GlTransaction> Handle(UpdateGlTransactionCommand request, CancellationToken cancellationToken)
        {

            var entity = request.glTransaction;

            var _entity = await _context.GlTransaction.FindAsync(request.glTransaction.Id);

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
