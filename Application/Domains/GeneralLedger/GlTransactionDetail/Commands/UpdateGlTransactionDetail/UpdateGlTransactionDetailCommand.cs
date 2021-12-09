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

namespace Application.Domains.GeneralLedger.GlTransactionDetail.Commands.UpdateGlTransactionDetail
{
    public class UpdateGlTransactionDetailCommand : IRequest<Application.Model.GeneralLedger.GlTransactionDetail>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.GeneralLedger.GlTransactionDetail GlTransactionDetail { get; set; }
    }

    public class UpdateGlTransactionDetailCommandHandler : IRequestHandler<UpdateGlTransactionDetailCommand, Application.Model.GeneralLedger.GlTransactionDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateGlTransactionDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.GeneralLedger.GlTransactionDetail> Handle(UpdateGlTransactionDetailCommand request, CancellationToken cancellationToken)
        {

            var entity = request.GlTransactionDetail;

            var _entity = await _context.GlTransactionDetail.FindAsync(request.GlTransactionDetail.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(GlTransactionDetail), entity.Id);
            }

            _context.GlTransactionDetail.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
