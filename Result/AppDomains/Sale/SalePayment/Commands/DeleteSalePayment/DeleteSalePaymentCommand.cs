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

namespace Application.Domains.Sale.SalePayment.Commands.DeleteSalePayment
{
    public class DeleteSalePaymentCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteSalePaymentCommandHandler : IRequestHandler<DeleteSalePaymentCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteSalePaymentCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteSalePaymentCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.SalePayment.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(SalePayment), request.Id);
            }

            _context.SalePayment.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
