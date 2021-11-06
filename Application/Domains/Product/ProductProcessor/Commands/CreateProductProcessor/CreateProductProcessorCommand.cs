using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Product;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Product.ProductProcessor.Commands.CreateProductProcessor
{
    public class CreateProductProcessorCommand : IRequest<DataAccessLayer.Model.Product.ProductProcessor>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.ProductProcessor productProcessor { get; set; }
    }

    public class CreateProductProcessorCommandHandler : IRequestHandler<CreateProductProcessorCommand, DataAccessLayer.Model.Product.ProductProcessor>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductProcessorCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductProcessor> Handle(CreateProductProcessorCommand request, CancellationToken cancellationToken)
        {
            var entity = request.productProcessor;

            _context.ProductProcessor.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
