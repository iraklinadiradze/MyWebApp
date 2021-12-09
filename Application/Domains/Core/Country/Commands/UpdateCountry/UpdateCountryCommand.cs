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

namespace Application.Domains.Core.Country.Commands.UpdateCountry
{
    public class UpdateCountryCommand : IRequest<Application.Model.Core.Country>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Core.Country Country { get; set; }
    }

    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Application.Model.Core.Country>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateCountryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Core.Country> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Country;

            var _entity = await _context.Country.FindAsync(request.Country.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Country), entity.Id);
            }

            _context.Country.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
