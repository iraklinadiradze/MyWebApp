using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.Core;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Core.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Application.Model.Core.User>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Core.User User { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Application.Model.Core.User>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateUserCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Core.User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var entity = request.User;

            var _entity = await _context.User.FindAsync(request.User.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(User), entity.Id);
            }

            _context.User.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
