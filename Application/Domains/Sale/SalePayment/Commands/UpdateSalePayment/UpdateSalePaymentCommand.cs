using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Sale;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Sale.SalePayment.Commands.UpdateSalePayment
{
    public class UpdateSalePaymentCommand : IRequest<DataAccessLayer.Model.Sale.SalePayment>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Sale.SalePayment SalePayment { get; set; }
    }

    public class UpdateSalePaymentCommandHandler : IRequestHandler<UpdateSalePaymentCommand, DataAccessLayer.Model.Sale.SalePayment>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateSalePaymentCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.SalePayment> Handle(UpdateSalePaymentCommand request, CancellationToken cancellationToken)
        {

            var entity = request.SalePayment;

            var _entity = await _context.SalePayment.FindAsync(request.SalePayment.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(SalePayment), entity.Id);
            }

            _context.SalePayment.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
