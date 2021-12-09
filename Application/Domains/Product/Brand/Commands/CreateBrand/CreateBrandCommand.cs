using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Product;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Product.Brand.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<Application.Model.Product.Brand>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.Brand Brand { get; set; }
    }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Application.Model.Product.Brand>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateBrandCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.Brand> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Brand;

            _context.Brand.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
