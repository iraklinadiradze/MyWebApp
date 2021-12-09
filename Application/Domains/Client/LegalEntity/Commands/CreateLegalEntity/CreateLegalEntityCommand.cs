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

namespace Application.Domains.Client.LegalEntity.Commands.CreateLegalEntity
{
    public class CreateLegalEntityCommand : IRequest<Application.Model.Client.LegalEntity>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Client.LegalEntity LegalEntity { get; set; }
    }

    public class CreateLegalEntityCommandHandler : IRequestHandler<CreateLegalEntityCommand, Application.Model.Client.LegalEntity>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateLegalEntityCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Client.LegalEntity> Handle(CreateLegalEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = request.LegalEntity;

            _context.LegalEntity.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
