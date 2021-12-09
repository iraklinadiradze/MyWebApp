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

namespace Application.Domains.Sale.ReturnProduct.Commands.CreateReturnProduct
{
    public class CreateReturnProductCommand : IRequest<Application.Model.Sale.ReturnProduct>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Sale.ReturnProduct ReturnProduct { get; set; }
    }

    public class CreateReturnProductCommandHandler : IRequestHandler<CreateReturnProductCommand, Application.Model.Sale.ReturnProduct>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateReturnProductCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Sale.ReturnProduct> Handle(CreateReturnProductCommand request, CancellationToken cancellationToken)
        {
            var entity = request.ReturnProduct;

            _context.ReturnProduct.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
