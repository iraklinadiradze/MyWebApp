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

namespace Application.Domains.Core.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<DataAccessLayer.Model.Core.User>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Core.User User { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, DataAccessLayer.Model.Core.User>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateUserCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Core.User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = request.User;

            _context.User.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
