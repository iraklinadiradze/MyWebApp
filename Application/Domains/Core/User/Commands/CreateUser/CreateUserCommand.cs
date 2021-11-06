using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Core;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Core.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<DataAccessLayer.Model.Core.User>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Core.User user { get; set; }
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
            var entity = request.user;

            _context.User.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
