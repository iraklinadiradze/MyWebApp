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

namespace Application.Domains.Sale.SalePaymentType.Commands.DeleteSalePaymentType
{
    public class DeleteSalePaymentTypeCommand : IRequest<int>
    {
        public int senderId { get; set; }  = 0;
        public int Id { get; set; }
    }

    public class DeleteSalePaymentTypeCommandHandler : IRequestHandler<DeleteSalePaymentTypeCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteSalePaymentTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteSalePaymentTypeCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.SalePaymentType.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(SalePaymentType), request.Id);
            }

            _context.SalePaymentType.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
