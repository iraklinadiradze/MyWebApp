using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Core;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Core.Country.Commands.CreateCountry
{
    public class CreateCountryCommand : IRequest<DataAccessLayer.Model.Core.Country>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Core.Country country { get; set; }
    }

    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, DataAccessLayer.Model.Core.Country>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateCountryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Core.Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = request.country;

            _context.Country.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
