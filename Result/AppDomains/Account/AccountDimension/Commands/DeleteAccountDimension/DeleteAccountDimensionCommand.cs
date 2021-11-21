using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Account;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Account.AccountDimension.Commands.DeleteAccountDimension
{
    public class DeleteAccountDimensionCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteAccountDimensionCommandHandler : IRequestHandler<DeleteAccountDimensionCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteAccountDimensionCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteAccountDimensionCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.AccountDimension.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(AccountDimension), request.Id);
            }

            _context.AccountDimension.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
