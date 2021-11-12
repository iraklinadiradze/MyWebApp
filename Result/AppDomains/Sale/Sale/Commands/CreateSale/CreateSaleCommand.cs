using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Sale;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Sale.Sale.Commands.CreateSale
{
    public class CreateSaleCommand : IRequest<DataAccessLayer.Model.Sale.Sale>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Sale.Sale sale { get; set; }
    }

    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, DataAccessLayer.Model.Sale.Sale>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateSaleCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.Sale> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var entity = request.sale;

            _context.Sale.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
