using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Product;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Product.Brand.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<DataAccessLayer.Model.Product.Brand>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.Brand brand { get; set; }
    }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, DataAccessLayer.Model.Product.Brand>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateBrandCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.Brand> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var entity = request.brand;

            _context.Brand.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
