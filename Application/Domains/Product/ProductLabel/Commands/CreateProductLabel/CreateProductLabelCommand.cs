using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Product;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Product.ProductLabel.Commands.CreateProductLabel
{
    public class CreateProductLabelCommand : IRequest<DataAccessLayer.Model.Product.ProductLabel>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.ProductLabel ProductLabel { get; set; }
    }

    public class CreateProductLabelCommandHandler : IRequestHandler<CreateProductLabelCommand, DataAccessLayer.Model.Product.ProductLabel>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductLabelCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductLabel> Handle(CreateProductLabelCommand request, CancellationToken cancellationToken)
        {
            var entity = request.ProductLabel;

            _context.ProductLabel.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
