using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Core;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Core.Entity.Commands.UpdateEntity
{
    public class UpdateEntityCommand : IRequest<DataAccessLayer.Model.Core.Entity>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Core.Entity Entity { get; set; }
    }

    public class UpdateEntityCommandHandler : IRequestHandler<UpdateEntityCommand, DataAccessLayer.Model.Core.Entity>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateEntityCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Core.Entity> Handle(UpdateEntityCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Entity;

            var _entity = await _context.Entity.FindAsync(request.Entity.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Entity), entity.Id);
            }

            _context.Entity.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
