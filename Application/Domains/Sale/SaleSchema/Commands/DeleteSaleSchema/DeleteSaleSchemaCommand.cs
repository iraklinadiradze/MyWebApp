using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.Sale;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Sale.SaleSchema.Commands.DeleteSaleSchema
{
    public class DeleteSaleSchemaCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteSaleSchemaCommandHandler : IRequestHandler<DeleteSaleSchemaCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteSaleSchemaCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteSaleSchemaCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.SaleSchema.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(SaleSchema), request.Id);
            }

            _context.SaleSchema.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
