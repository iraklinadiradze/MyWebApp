using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Product;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Product.Brand.Commands.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<DataAccessLayer.Model.Product.Brand>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.Brand Brand { get; set; }
    }

    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, DataAccessLayer.Model.Product.Brand>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateBrandCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.Brand> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Brand;

            var _entity = await _context.Brand.FindAsync(request.Brand.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Brand), entity.Id);
            }

            _context.Brand.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
