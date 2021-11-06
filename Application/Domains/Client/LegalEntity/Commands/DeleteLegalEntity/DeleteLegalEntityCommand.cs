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

namespace Application.Domains.Client.LegalEntity.Commands.DeleteLegalEntity
{
    public class DeleteLegalEntityCommand : IRequest<int>
    {
        public int senderId { get; set; }  = 0;
        public int Id { get; set; }
    }

    public class DeleteLegalEntityCommandHandler : IRequestHandler<DeleteLegalEntityCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteLegalEntityCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteLegalEntityCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.LegalEntity.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(LegalEntity), request.Id);
            }

            _context.LegalEntity.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
