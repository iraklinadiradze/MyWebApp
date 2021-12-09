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

namespace Application.Domains.Sale.SaleSchema.Commands.CreateSaleSchema
{
    public class CreateSaleSchemaCommand : IRequest<Application.Model.Sale.SaleSchema>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Sale.SaleSchema SaleSchema { get; set; }
    }

    public class CreateSaleSchemaCommandHandler : IRequestHandler<CreateSaleSchemaCommand, Application.Model.Sale.SaleSchema>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateSaleSchemaCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Sale.SaleSchema> Handle(CreateSaleSchemaCommand request, CancellationToken cancellationToken)
        {
            var entity = request.SaleSchema;

            _context.SaleSchema.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
