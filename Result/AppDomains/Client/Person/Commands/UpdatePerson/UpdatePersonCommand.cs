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

namespace Application.Domains.Client.Person.Commands.UpdatePerson
{
    public class UpdatePersonCommand : IRequest<DataAccessLayer.Model.Client.Person>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Client.Person person { get; set; }
    }

    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, DataAccessLayer.Model.Client.Person>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePersonCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Client.Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {

            var entity = request.person;

            var _entity = await _context.Person.FindAsync(request.person.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Person), entity.Id);
            }

            _context.Person.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
