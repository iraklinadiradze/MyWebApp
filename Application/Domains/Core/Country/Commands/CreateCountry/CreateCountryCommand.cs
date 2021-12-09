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

namespace Application.Domains.Core.Country.Commands.CreateCountry
{
    public class CreateCountryCommand : IRequest<Application.Model.Core.Country>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Core.Country Country { get; set; }
    }

    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Application.Model.Core.Country>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateCountryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Core.Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Country;

            _context.Country.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
