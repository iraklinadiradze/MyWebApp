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

namespace Application.Domains.Sale.Sale.Commands.CreateSale
{
    public class CreateSaleCommand : IRequest<Application.Model.Sale.Sale>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Sale.Sale Sale { get; set; }
    }

    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, Application.Model.Sale.Sale>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateSaleCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Sale.Sale> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Sale;

            _context.Sale.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
