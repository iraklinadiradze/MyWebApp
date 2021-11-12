using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Sale;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Sale.SalePayment.Commands.CreateSalePayment
{
    public class CreateSalePaymentCommand : IRequest<DataAccessLayer.Model.Sale.SalePayment>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Sale.SalePayment salePayment { get; set; }
    }

    public class CreateSalePaymentCommandHandler : IRequestHandler<CreateSalePaymentCommand, DataAccessLayer.Model.Sale.SalePayment>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateSalePaymentCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.SalePayment> Handle(CreateSalePaymentCommand request, CancellationToken cancellationToken)
        {
            var entity = request.salePayment;

            _context.SalePayment.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
