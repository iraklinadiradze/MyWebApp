using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Client;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Client.LegalEntity.Commands.CreateLegalEntity
{
    public class CreateLegalEntityCommand : IRequest<DataAccessLayer.Model.Client.LegalEntity>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Client.LegalEntity legalEntity { get; set; }
    }

    public class CreateLegalEntityCommandHandler : IRequestHandler<CreateLegalEntityCommand, DataAccessLayer.Model.Client.LegalEntity>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateLegalEntityCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Client.LegalEntity> Handle(CreateLegalEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = request.legalEntity;

            _context.LegalEntity.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
