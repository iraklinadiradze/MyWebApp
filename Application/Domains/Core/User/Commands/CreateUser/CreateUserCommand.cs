using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Core;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Core.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Application.Model.Core.User>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Core.User User { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Application.Model.Core.User>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateUserCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Core.User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = request.User;

            _context.User.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
