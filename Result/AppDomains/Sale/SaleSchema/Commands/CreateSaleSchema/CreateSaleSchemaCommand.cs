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

namespace Application.Domains.Sale.SaleSchema.Commands.CreateSaleSchema
{
    public class CreateSaleSchemaCommand : IRequest<DataAccessLayer.Model.Sale.SaleSchema>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Sale.SaleSchema SaleSchema { get; set; }
    }

    public class CreateSaleSchemaCommandHandler : IRequestHandler<CreateSaleSchemaCommand, DataAccessLayer.Model.Sale.SaleSchema>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateSaleSchemaCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.SaleSchema> Handle(CreateSaleSchemaCommand request, CancellationToken cancellationToken)
        {
            var entity = request.SaleSchema;

            _context.SaleSchema.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
