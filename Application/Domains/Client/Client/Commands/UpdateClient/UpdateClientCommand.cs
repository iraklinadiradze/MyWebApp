using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Client;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Client.Client.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<DataAccessLayer.Model.Client.Client>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Client.Client Client { get; set; }
    }

    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, DataAccessLayer.Model.Client.Client>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateClientCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Client.Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Client;

            var _entity = await _context.Client.FindAsync(request.Client.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Client), entity.Id);
            }

            _context.Client.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
