using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Client;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Client.Client.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<Application.Model.Client.Client>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Client.Client Client { get; set; }
    }

    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Application.Model.Client.Client>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateClientCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Client.Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Client;

            _context.Client.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
