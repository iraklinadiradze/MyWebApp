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

namespace Application.Domains.Client.Person.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<Application.Model.Client.Person>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Client.Person Person { get; set; }
    }

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Application.Model.Client.Person>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePersonCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Client.Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Person;

            _context.Person.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
