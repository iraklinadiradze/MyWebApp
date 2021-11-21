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

namespace Application.Domains.Sale.ReturnProduct.Commands.UpdateReturnProduct
{
    public class UpdateReturnProductCommand : IRequest<DataAccessLayer.Model.Sale.ReturnProduct>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Sale.ReturnProduct ReturnProduct { get; set; }
    }

    public class UpdateReturnProductCommandHandler : IRequestHandler<UpdateReturnProductCommand, DataAccessLayer.Model.Sale.ReturnProduct>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateReturnProductCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.ReturnProduct> Handle(UpdateReturnProductCommand request, CancellationToken cancellationToken)
        {

            var entity = request.ReturnProduct;

            var _entity = await _context.ReturnProduct.FindAsync(request.ReturnProduct.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ReturnProduct), entity.Id);
            }

            _context.ReturnProduct.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
