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

namespace Application.Domains.GeneralLedger.GlTransactionDetail.Commands.UpdateGlTransactionDetail
{
    public class UpdateGlTransactionDetailCommand : IRequest<DataAccessLayer.Model.GeneralLedger.GlTransactionDetail>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.GeneralLedger.GlTransactionDetail glTransactionDetail { get; set; }
    }

    public class UpdateGlTransactionDetailCommandHandler : IRequestHandler<UpdateGlTransactionDetailCommand, DataAccessLayer.Model.GeneralLedger.GlTransactionDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateGlTransactionDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.GeneralLedger.GlTransactionDetail> Handle(UpdateGlTransactionDetailCommand request, CancellationToken cancellationToken)
        {

            var entity = request.glTransactionDetail;

            var _entity = await _context.GlTransactionDetail.FindAsync(request.glTransactionDetail.Id);

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
