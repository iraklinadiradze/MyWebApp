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

namespace Application.Domains.Sale.Sale.Commands.UpdateSale
{
    public class UpdateSaleCommand : IRequest<DataAccessLayer.Model.Sale.Sale>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Sale.Sale sale { get; set; }
    }

    public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, DataAccessLayer.Model.Sale.Sale>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateSaleCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.Sale> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {

            var entity = request.sale;

            var _entity = await _context.Sale.FindAsync(request.sale.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Sale), entity.Id);
            }

            _context.Sale.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
