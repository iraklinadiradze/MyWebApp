using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Account;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Account.AccountDimension.Commands.CreateAccountDimension
{
    public class CreateAccountDimensionCommand : IRequest<DataAccessLayer.Model.Account.AccountDimension>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Account.AccountDimension accountDimension { get; set; }
    }

    public class CreateAccountDimensionCommandHandler : IRequestHandler<CreateAccountDimensionCommand, DataAccessLayer.Model.Account.AccountDimension>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateAccountDimensionCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Account.AccountDimension> Handle(CreateAccountDimensionCommand request, CancellationToken cancellationToken)
        {
            var entity = request.accountDimension;

            _context.AccountDimension.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
