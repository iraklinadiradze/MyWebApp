using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.Sale;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Sale.SalePaymentType.Commands.UpdateSalePaymentType
{
    public class UpdateSalePaymentTypeCommand : IRequest<Application.Model.Sale.SalePaymentType>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Sale.SalePaymentType SalePaymentType { get; set; }
    }

    public class UpdateSalePaymentTypeCommandHandler : IRequestHandler<UpdateSalePaymentTypeCommand, Application.Model.Sale.SalePaymentType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateSalePaymentTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Sale.SalePaymentType> Handle(UpdateSalePaymentTypeCommand request, CancellationToken cancellationToken)
        {

            var entity = request.SalePaymentType;

            var _entity = await _context.SalePaymentType.FindAsync(request.SalePaymentType.Id);

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
