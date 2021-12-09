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

namespace Application.Domains.Sale.SalePaymentType.Commands.CreateSalePaymentType
{
    public class CreateSalePaymentTypeCommand : IRequest<Application.Model.Sale.SalePaymentType>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Sale.SalePaymentType SalePaymentType { get; set; }
    }

    public class CreateSalePaymentTypeCommandHandler : IRequestHandler<CreateSalePaymentTypeCommand, Application.Model.Sale.SalePaymentType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateSalePaymentTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Sale.SalePaymentType> Handle(CreateSalePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = request.SalePaymentType;

            _context.SalePaymentType.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
