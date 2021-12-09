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

namespace Application.Domains.Product.ProductProcessor.Commands.CreateProductProcessor
{
    public class CreateProductProcessorCommand : IRequest<Application.Model.Product.ProductProcessor>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.ProductProcessor ProductProcessor { get; set; }
    }

    public class CreateProductProcessorCommandHandler : IRequestHandler<CreateProductProcessorCommand, Application.Model.Product.ProductProcessor>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductProcessorCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.ProductProcessor> Handle(CreateProductProcessorCommand request, CancellationToken cancellationToken)
        {
            var entity = request.ProductProcessor;

            _context.ProductProcessor.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
