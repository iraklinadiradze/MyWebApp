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

namespace Application.Domains.Sale.SalePaymentType.Commands.UpdateSalePaymentType
{
    public class UpdateSalePaymentTypeCommand : IRequest<DataAccessLayer.Model.Sale.SalePaymentType>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Sale.SalePaymentType salePaymentType { get; set; }
    }

    public class UpdateSalePaymentTypeCommandHandler : IRequestHandler<UpdateSalePaymentTypeCommand, DataAccessLayer.Model.Sale.SalePaymentType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateSalePaymentTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.SalePaymentType> Handle(UpdateSalePaymentTypeCommand request, CancellationToken cancellationToken)
        {

            var entity = request.salePaymentType;

            var _entity = await _context.SalePaymentType.FindAsync(request.salePaymentType.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(SalePaymentType), entity.Id);
            }

            _context.SalePaymentType.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
