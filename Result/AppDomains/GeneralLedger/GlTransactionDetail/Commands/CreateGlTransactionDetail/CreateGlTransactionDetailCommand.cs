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

namespace Application.Domains.GeneralLedger.GlTransactionDetail.Commands.CreateGlTransactionDetail
{
    public class CreateGlTransactionDetailCommand : IRequest<DataAccessLayer.Model.GeneralLedger.GlTransactionDetail>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.GeneralLedger.GlTransactionDetail GlTransactionDetail { get; set; }
    }

    public class CreateGlTransactionDetailCommandHandler : IRequestHandler<CreateGlTransactionDetailCommand, DataAccessLayer.Model.GeneralLedger.GlTransactionDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateGlTransactionDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.GeneralLedger.GlTransactionDetail> Handle(CreateGlTransactionDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = request.GlTransactionDetail;

            _context.GlTransactionDetail.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
