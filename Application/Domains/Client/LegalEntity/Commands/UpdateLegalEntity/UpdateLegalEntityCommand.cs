using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.Client;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Client.LegalEntity.Commands.UpdateLegalEntity
{
    public class UpdateLegalEntityCommand : IRequest<Application.Model.Client.LegalEntity>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Client.LegalEntity LegalEntity { get; set; }
    }

    public class UpdateLegalEntityCommandHandler : IRequestHandler<UpdateLegalEntityCommand, Application.Model.Client.LegalEntity>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateLegalEntityCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Client.LegalEntity> Handle(UpdateLegalEntityCommand request, CancellationToken cancellationToken)
        {

            var entity = request.LegalEntity;

            var _entity = await _context.LegalEntity.FindAsync(request.LegalEntity.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(LegalEntity), entity.Id);
            }

            _context.LegalEntity.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
