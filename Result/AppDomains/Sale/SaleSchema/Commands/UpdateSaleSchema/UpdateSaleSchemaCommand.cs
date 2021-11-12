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

namespace Application.Domains.Sale.SaleSchema.Commands.UpdateSaleSchema
{
    public class UpdateSaleSchemaCommand : IRequest<DataAccessLayer.Model.Sale.SaleSchema>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Sale.SaleSchema saleSchema { get; set; }
    }

    public class UpdateSaleSchemaCommandHandler : IRequestHandler<UpdateSaleSchemaCommand, DataAccessLayer.Model.Sale.SaleSchema>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateSaleSchemaCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.SaleSchema> Handle(UpdateSaleSchemaCommand request, CancellationToken cancellationToken)
        {

            var entity = request.saleSchema;

            var _entity = await _context.SaleSchema.FindAsync(request.saleSchema.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(SaleSchema), entity.Id);
            }

            _context.SaleSchema.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
