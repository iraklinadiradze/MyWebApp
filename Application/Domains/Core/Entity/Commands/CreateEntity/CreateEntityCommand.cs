using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Core;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Core.Entity.Commands.CreateEntity
{
    public class CreateEntityCommand : IRequest<DataAccessLayer.Model.Core.Entity>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Core.Entity Entity { get; set; }
    }

    public class CreateEntityCommandHandler : IRequestHandler<CreateEntityCommand, DataAccessLayer.Model.Core.Entity>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateEntityCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Core.Entity> Handle(CreateEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;

            _context.Entity.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
