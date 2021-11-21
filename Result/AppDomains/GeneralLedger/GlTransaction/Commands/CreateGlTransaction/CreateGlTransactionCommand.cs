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

namespace Application.Domains.GeneralLedger.GlTransaction.Commands.CreateGlTransaction
{
    public class CreateGlTransactionCommand : IRequest<DataAccessLayer.Model.GeneralLedger.GlTransaction>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.GeneralLedger.GlTransaction GlTransaction { get; set; }
    }

    public class CreateGlTransactionCommandHandler : IRequestHandler<CreateGlTransactionCommand, DataAccessLayer.Model.GeneralLedger.GlTransaction>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateGlTransactionCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.GeneralLedger.GlTransaction> Handle(CreateGlTransactionCommand request, CancellationToken cancellationToken)
        {
            var entity = request.GlTransaction;

            _context.GlTransaction.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
