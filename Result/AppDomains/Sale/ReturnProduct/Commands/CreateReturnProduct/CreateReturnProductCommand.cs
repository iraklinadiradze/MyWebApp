using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Sale;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Sale.ReturnProduct.Commands.CreateReturnProduct
{
    public class CreateReturnProductCommand : IRequest<DataAccessLayer.Model.Sale.ReturnProduct>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Sale.ReturnProduct ReturnProduct { get; set; }
    }

    public class CreateReturnProductCommandHandler : IRequestHandler<CreateReturnProductCommand, DataAccessLayer.Model.Sale.ReturnProduct>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateReturnProductCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.ReturnProduct> Handle(CreateReturnProductCommand request, CancellationToken cancellationToken)
        {
            var entity = request.ReturnProduct;

            _context.ReturnProduct.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
