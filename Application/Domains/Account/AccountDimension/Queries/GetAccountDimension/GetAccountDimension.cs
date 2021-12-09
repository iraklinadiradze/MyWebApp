using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Account;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Account.AccountDimension.Queries.GetAccountDimension
{

    public class GetAccountDimensionQuery : IRequest<Application.Model.Account.AccountDimension>
    {
        public int? Id { get; set; }
    }

    public class GetAccountDimensionQueryHandler : IRequestHandler<GetAccountDimensionQuery, Application.Model.Account.AccountDimension>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetAccountDimensionQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Account.AccountDimension> Handle(GetAccountDimensionQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.AccountDimension
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(AccountDimension), request.Id);
            }

            return entity;

        }

    }
}
