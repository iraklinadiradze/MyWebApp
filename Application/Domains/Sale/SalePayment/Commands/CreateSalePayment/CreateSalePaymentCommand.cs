using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Sale;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Sale.SalePayment.Commands.CreateSalePayment
{
    public class CreateSalePaymentCommand : IRequest<Application.Model.Sale.SalePayment>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Sale.SalePayment SalePayment { get; set; }
    }

    public class CreateSalePaymentCommandHandler : IRequestHandler<CreateSalePaymentCommand, Application.Model.Sale.SalePayment>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateSalePaymentCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Sale.SalePayment> Handle(CreateSalePaymentCommand request, CancellationToken cancellationToken)
        {
            var entity = request.SalePayment;

            _context.SalePayment.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
