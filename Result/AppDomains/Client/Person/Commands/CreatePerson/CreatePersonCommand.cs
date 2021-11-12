using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Client;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Client.Person.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<DataAccessLayer.Model.Client.Person>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Client.Person person { get; set; }
    }

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, DataAccessLayer.Model.Client.Person>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePersonCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Client.Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = request.person;

            _context.Person.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
