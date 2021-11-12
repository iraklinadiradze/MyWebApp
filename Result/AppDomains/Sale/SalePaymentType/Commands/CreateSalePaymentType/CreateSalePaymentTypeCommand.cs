using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Sale;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Sale.SalePaymentType.Commands.CreateSalePaymentType
{
    public class CreateSalePaymentTypeCommand : IRequest<DataAccessLayer.Model.Sale.SalePaymentType>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Sale.SalePaymentType salePaymentType { get; set; }
    }

    public class CreateSalePaymentTypeCommandHandler : IRequestHandler<CreateSalePaymentTypeCommand, DataAccessLayer.Model.Sale.SalePaymentType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateSalePaymentTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.SalePaymentType> Handle(CreateSalePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = request.salePaymentType;

            _context.SalePaymentType.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
